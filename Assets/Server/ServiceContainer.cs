﻿using System;
using System.Collections.Generic;

public static class ServiceContainer
{
    static readonly Dictionary<Type, object> registeredServices = new Dictionary<Type, object>();

    public static T GetService<T>() where T:class
    {
        var type = typeof(T);
        lock (registeredServices)
        {
            if (registeredServices.ContainsKey(type)) return (T)registeredServices[type];
        }
        return null;
    }

    public static void AddService<T>(T service) where T:class
    {
        if (service == null) throw new ArgumentNullException("service");
        var type = typeof(T);
        lock (registeredServices)
        {
            if (registeredServices.ContainsKey(type)) throw new ArgumentException("Service is already registered with this type", type.Name);
            registeredServices.Add(type, service);
        }
    }

    public static void RemoveService<T>() where T : class
    {
        var type = typeof(T);
        lock (registeredServices)
        {
            registeredServices.Remove(type);
        }
    }
}