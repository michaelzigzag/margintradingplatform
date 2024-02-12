using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class PriceBar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("time")]
    public DateTime Time { get; set; }
    [BsonElement("open")]
    public decimal Open { get; set; }
    [BsonElement("high")]
    public decimal High { get; set; }
    [BsonElement("low")]
    public decimal Low { get; set; }
    [BsonElement("close")]
    public decimal Close { get; set; }
    [BsonElement("volume")]
    public decimal Volume { get; set; }
    [BsonElement("instrumentId")]
    public string InstrumentId { get; set; }
}