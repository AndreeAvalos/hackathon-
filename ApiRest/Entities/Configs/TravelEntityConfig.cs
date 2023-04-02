using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class TravelEntityConfig : IEntityTypeConfiguration<TravelEntity>
{
    public void Configure(EntityTypeBuilder<TravelEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/travel.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(reader, csvConfig);
        csvReader.Context.RegisterClassMap<TravelMap>();
        IEnumerable<TravelEntity> records = csvReader.GetRecords<TravelEntity>();
        builder.HasData(records);
    }
}

internal class TravelMap : ClassMap<TravelEntity>
{
    public TravelMap()
    {
        

        Map(entity => entity.Id).Index(0);
        Map(entity => entity.Destination).Index(1);
        Map(entity => entity.TravelDate)
            .TypeConverter<DateTimeConverter>()
            .TypeConverterOption.Format("dd/MM/yyyy").Index(2);
        Map(entity => entity.IssuanceCatalogId).Index(3);
        Map(entity => entity.TravelCatalogId).Index(4);
    }
}