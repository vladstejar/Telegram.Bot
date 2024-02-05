// Global using directives

global using System;

#if !NET8_0_OR_GREATER
global using Newtonsoft.Json;
global using Newtonsoft.Json.Serialization;
#else
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using JsonException = System.Text.Json.JsonException;
#endif
