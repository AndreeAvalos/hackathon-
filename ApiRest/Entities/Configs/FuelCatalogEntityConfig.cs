using System.Globalization;
using ApiRest.Entities.Catalogs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class FuelCatalogEntityConfig: IEntityTypeConfiguration<FuelCatalogEntity>
{
    public void Configure(EntityTypeBuilder<FuelCatalogEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/fuel_catalog.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        IEnumerable<FuelCatalogEntity> records = csvReader.GetRecords<FuelCatalogEntity>();
        builder.HasData(records);
    }
}