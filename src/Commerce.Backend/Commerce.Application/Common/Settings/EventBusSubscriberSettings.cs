﻿namespace Commerce.Application.Common.Settings;

public abstract class EventBusSubscriberSettings
{
    public ushort PrefetchCount { get; set; }
}
