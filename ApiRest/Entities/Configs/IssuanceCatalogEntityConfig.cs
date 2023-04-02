using System.Globalization;
using ApiRest.Entities.Catalogs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class IssuanceCatalogEntityConfig: IEntityTypeConfiguration<IssuanceCatalogEntity>
{
    public void Configure(EntityTypeBuilder<IssuanceCatalogEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/issuance_catalog.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        IEnumerable<IssuanceCatalogEntity> records = csvReader.GetRecords<IssuanceCatalogEntity>();
        builder.HasData(records);
    }
}