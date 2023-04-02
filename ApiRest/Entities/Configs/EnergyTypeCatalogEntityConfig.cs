using System.Globalization;
using ApiRest.Entities.Catalogs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class EnergyTypeCatalogEntityConfig: IEntityTypeConfiguration<EnergyTypeCatalogEntity>
{
    public void Configure(EntityTypeBuilder<EnergyTypeCatalogEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/energy_type_catalog.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        IEnumerable<EnergyTypeCatalogEntity> records = csvReader.GetRecords<EnergyTypeCatalogEntity>();
        builder.HasData(records);
    }
}