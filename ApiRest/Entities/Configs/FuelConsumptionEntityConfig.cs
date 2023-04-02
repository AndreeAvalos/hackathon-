using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class FuelConsumptionEntityConfig : IEntityTypeConfiguration<FuelConsumptionEntity>
{
    public void Configure(EntityTypeBuilder<FuelConsumptionEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/fuel.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        csvReader.Context.RegisterClassMap<FuelConsumptionMap>();
        IEnumerable<FuelConsumptionEntity> records = csvReader.GetRecords<FuelConsumptionEntity>();
        builder.HasData(records);
    }
}

internal class FuelConsumptionMap : ClassMap<FuelConsumptionEntity>
{
    public FuelConsumptionMap()
    {
        Map(entity => entity.Id).Index(0);
        Map(entity => entity.Units).Index(1);
        Map(entity => entity.ConsumptionDate)
            .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
            .TypeConverterOption.Format("dd/MM/yyyy").Index(2);
        Map(entity => entity.FuelCatalogId).Index(3);
        Map(entity => entity.IssuanceCatalogId).Index(4);
    }
}