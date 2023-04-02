using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class EnergyConsumptionEntityConfig : IEntityTypeConfiguration<EnergyConsumptionEntity>
{
    public void Configure(EntityTypeBuilder<EnergyConsumptionEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/energy.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        csvReader.Context.RegisterClassMap<EnergyConsumptionMap>();
        IEnumerable<EnergyConsumptionEntity> records = csvReader.GetRecords<EnergyConsumptionEntity>();
        builder.HasData(records);
    }
}

internal class EnergyConsumptionMap : ClassMap<EnergyConsumptionEntity>
{
    public EnergyConsumptionMap()
    {
        Map(entity => entity.Id).Index(0);
        Map(entity => entity.Units).Index(1);
        Map(entity => entity.ConsumptionDate)
            .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
            .TypeConverterOption.Format("dd/MM/yyyy").Index(2);
        Map(entity => entity.EnergyCatalogId).Index(3);
        Map(entity => entity.IssuanceCatalogId).Index(4);
        Map(entity => entity.EnergyTypeCatalogId).Index(5);
    }
}