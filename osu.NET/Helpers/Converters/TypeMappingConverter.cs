using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace osu.NET.Helpers.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> that deserializes the JSON object into a type provided via the base type with a mapping function.
/// </summary>
/// <typeparam name="TBase">The base type of the objects being deserialized.</typeparam>
/// <param name="mapping">
/// A function that takes an instance of <typeparamref name="TBase"/> and returns the corresponding derived type 
/// that should be used for deserialization.
/// </param>
internal class TypeMappingConverter<TBase>(Func<TBase, Type> mapping) : JsonConverter
{
  /// <inheritdoc/>
  public override bool CanWrite => false;

  /// <inheritdoc/>
  public override bool CanConvert(Type objectType) => objectType.IsAssignableTo(typeof(TBase));

  /// <inheritdoc/>
  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    JObject obj = JObject.Load(reader);

    // Deserialize with a temporary json serializer excluding this converter itself to prevent infinite recursion.)
    JsonSerializer tempSerializer = JsonSerializer.Create(new() { Converters = [..serializer.Converters.Except([this])] });

    if (obj.ToObject<TBase>(tempSerializer) is not TBase @base)
      return null;

    return obj.ToObject(mapping(@base), tempSerializer);
  }

  /// <inheritdoc/>
  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}