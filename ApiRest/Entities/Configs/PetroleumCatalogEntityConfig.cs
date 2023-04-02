using System.Globalization;
using ApiRest.Entities.Catalogs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRest.Entities.Configs;

public class PetroleumCatalogEntityConfig: IEntityTypeConfiguration<PetroleumCatalogEntity>
{
    public void Configure(EntityTypeBuilder<PetroleumCatalogEntity> builder)
    {
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("now()");
        TextReader reader = new StreamReader("./Database/DataSeed/petroleum_catalog.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        IEnumerable<PetroleumCatalogEntity> records = csvReader.GetRecords<PetroleumCatalogEntity>();
        builder.HasData(records);
    }
}