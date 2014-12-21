Imports Bwl.Hardware.SimplSerial.SimplSerialBus

Public Class SimplSerailManager
	Private _logger As Logger
	Private ReadOnly _bus As SimplSerialBus
	Private ReadOnly _busLocker As New Object
	Private _storage As SettingsStorage
	Private ReadOnly _rand As New Random(CInt(DateTime.Now.Ticks >> 32))
	Private ReadOnly _adresses As New Dictionary(Of String, UShort)

	Public Sub New(logger As Logger, storage As SettingsStorage)
		_logger = logger
		_storage = storage
		_bus = New SimplSerialBus(_storage.CreateChildStorage("SimplSerial"))

		CheckConnection()
	End Sub

	Public ReadOnly Property SSBus As SimplSerialBus
		Get
			Return _bus
		End Get
	End Property

	Public Function CheckConnection() As Boolean
		Dim res = False

		SyncLock (_busLocker)
			If _bus IsNot Nothing AndAlso _bus.IsConnected Then
				_bus.Disconnect()
			End If
			If Not _bus.IsConnected Then
				'_logger.AddMessage("Порт " + PortName.Value + " не подключен!")
				Threading.Thread.Sleep(100)
				Try
					_bus.Connect()
				Catch ex As Exception
					_logger.AddWarning("SimplSerailManager - " + ex.Message)
				End Try
				res = _bus.IsConnected
			End If
		End SyncLock

		Return res
	End Function

	Public Function PrepareAndGetShortAddr(addressGuid As Guid) As UShort
		Dim shortAddr As UShort = 0
		SyncLock (_busLocker)
			If CheckConnection() Then
				Try
					shortAddr = GetShortAddr(addressGuid)
					If shortAddr > 0 Then
						_bus.RequestSetAddress(addressGuid, shortAddr)
					End If
				Catch ex As Exception
					_logger.AddError("SimplSerialManager.GetResponse - " + ex.ToString)
				End Try
			End If
		End SyncLock
		Return shortAddr
	End Function

	Public Function GetShortAddr(AddressGuid As Guid) As UShort
		SyncLock (_busLocker)
			SyncLock (_adresses)
				Dim guidStr = AddressGuid.ToString()
				Dim shortAddr = _rand.Next(UShort.MaxValue)
				If _adresses.ContainsKey(guidStr) Then
					shortAddr = _adresses(guidStr)
				End If

				If _bus IsNot Nothing Then
					While (True)
						Dim res = _bus.RequestDeviceInfo(shortAddr)
						If (res.Response.ResponseState <> ResponseState.ok) OrElse (res.DeviceGuid = AddressGuid) Then
							Exit While
						End If
						shortAddr = _rand.Next(UShort.MaxValue)
					End While
				End If

				_adresses(guidStr) = shortAddr
				Return shortAddr
			End SyncLock
		End SyncLock
	End Function
End Class
