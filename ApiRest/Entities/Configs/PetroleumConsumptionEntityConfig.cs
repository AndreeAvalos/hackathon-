using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class PetroleumConsumptionEntityConfig : IEntityTypeConfiguration<PetroleumConsumptionEntity>
{
    public void Configure(EntityTypeBuilder<PetroleumConsumptionEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/petroleum.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        csvReader.Context.RegisterClassMap<PetroleumConsumptionMap>();
        IEnumerable<PetroleumConsumptionEntity> records = csvReader.GetRecords<PetroleumConsumptionEntity>();
        builder.HasData(records);
    }
}

internal class PetroleumConsumptionMap : ClassMap<PetroleumConsumptionEntity>
{
    public PetroleumConsumptionMap()
    {
        Map(entity => entity.Id).Index(0);
        Map(entity => entity.Units).Index(1);
        Map(entity => entity.ConsumptionDate)
            .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
            .TypeConverterOption.Format("dd/MM/yyyy").Index(2);
        Map(entity => entity.PetroleumCatalogId).Index(3);
        Map(entity => entity.IssuanceCatalogId).Index(4);
        Map(entity => entity.DerivativeCatalogId).Index(5);
    }
}