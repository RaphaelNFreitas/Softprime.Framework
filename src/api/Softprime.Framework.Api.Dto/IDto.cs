﻿namespace Softprime.Framework.Api.Dto
{
    public interface IDto<TId>
    {
        TId Id { get; set; }
    }
}
