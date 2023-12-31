using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using ResumeTech.Application.Serialization;
using ResumeTech.Common.Json;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;

namespace ResumeTech.Application.Util; 

public static class SerializationUtils {
    
    public static void ConfigureJson(this WebApplicationBuilder builder, IList<TypeMapping> typeMappings) {
        // Apply custom json settings to controllers
        IJsonParser.Default = new DefaultJsonParser(CreateDefaultOptions(typeMappings));
        builder.Services.Configure<JsonOptions>(o => o.CopyOptionsFrom(IJsonParser.Default.Options));
        builder.Services.Configure<MvcJsonOptions>(o => o.CopyOptionsFrom(IJsonParser.Default.Options));
    }

    private static void AddJsonConverter(this JsonOptions options, JsonConverter converter) {
        options.SerializerOptions.Converters.Add(converter);
    }

    private static void AddJsonConverter(this MvcJsonOptions options, JsonConverter converter) {
        options.JsonSerializerOptions.Converters.Add(converter);
    }

    private static void CopyOptionsFrom(this JsonOptions self, JsonSerializerOptions options) {
        foreach (var jsonConverter in options.Converters) {
            self.AddJsonConverter(jsonConverter);
        }
        self.SerializerOptions.TypeInfoResolver = options.TypeInfoResolver;
        self.SerializerOptions.PropertyNamingPolicy = options.PropertyNamingPolicy;
    }

    private static void CopyOptionsFrom(this MvcJsonOptions self, JsonSerializerOptions options) {
        foreach (var jsonConverter in options.Converters) {
            self.AddJsonConverter(jsonConverter);
        }
        self.JsonSerializerOptions.TypeInfoResolver = options.TypeInfoResolver;
        self.JsonSerializerOptions.PropertyNamingPolicy = options.PropertyNamingPolicy;
    }

    private static JsonSerializerOptions CreateDefaultOptions(IList<TypeMapping> typeMappings) {
        JsonSerializerOptions options = new() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            // TypeInfoResolver = new PrivateConstructorContractResolver(),
            Converters = {
                new JsonStringEnumConverter()
            }
        };

        var customConverters = typeMappings
            .Select(t => t.JsonConverter)
            .Where(t => t != null);

        foreach (var converter in customConverters) {
            options.Converters.Add(converter!);
        }
        // options.Converters.Add(new WhiteSpaceTrimStringConverter()); // TODO
        return options;
    }

}