﻿using System;

namespace Projeto.Base.CrossCutting.Configuration.Exceptions
{
    public class SettingsReaderException : Exception
    {

        public SettingsReaderException(Exception innerException) : base("Settings file could not be read. please check inner exception", innerException)
        {
        }
    }
}