﻿using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.Enumerations;

public class ConnectionType : Enumeration
{
    public static ConnectionType LOCAL_CONNECTION = new(1, "Локальное подключение");
    public static ConnectionType NETWORK_CONNECTION = new(2, "Сетевое подключение");

    public ConnectionType(int id, string value) 
        : base(id, value) { }

    public static ConnectionType GetStatus(int code)
    {
        return code switch
        {
            1 => ConnectionType.LOCAL_CONNECTION,
            3 => ConnectionType.NETWORK_CONNECTION,
            _ => throw new Exception($"Unknown connection type code: {code}")
        };
    }
}
