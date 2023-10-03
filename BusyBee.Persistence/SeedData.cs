using BusyBee.Core.Entities;
using BusyBee.Core.Enums;
using BusyBee.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BusyBee.Persistence;

public static class SeedDataExtension
{
    public static void SeedData(this ModelBuilder builder)
    {
        builder.Entity<CategoryOfCategories>().HasData(
            new CategoryOfCategories
            {
                Id = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                ParentId = null,
                Title = "Дім",
                IconFilename = "category_icon_dim.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("EF5ED6A2-3FDA-4307-97A5-E6600D8E1C52"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Домашній майстер",
                IconFilename = "category_icon_domashniy_master.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("BA194614-FDC8-4830-BDE0-647532E7DA46"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Клінінгові послуги",
                IconFilename = "category_icon_cliningovi_poslugi.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("2FF6AC44-616C-491E-99A4-184B12719B35"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Оздоблювальні роботи",
                IconFilename = "category_icon_ozdoblyvalni_roboti.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("59E69EB2-B25D-40FA-AE1B-2E131E5EE44B"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Ремонт техніки",
                IconFilename = "category_icon_remont_texniki.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("413EFB83-BD36-425D-A5E4-0B9D13888D7B"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Будівельні роботи",
                IconFilename = "category_icon_budivelni_roboti.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("7F86E643-CADD-4DEA-9A76-22987EC2667B"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Побутові послуги",
                IconFilename = "category_icon_pobutovi_poslugi.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("BA72F604-2C3F-42A1-9838-8A4AB3E4F9BE"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Послуги для тварин",
                IconFilename = "category_icon_poslugi_dlya_tvarin.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("A518D3C3-2FE5-4746-A4E5-E59EA9607EE0"),
                ParentId = new Guid("08F60624-5D16-4FFF-9D2A-004A2087D0E6"),
                Title = "Меблеві роботи",
                IconFilename = "category_icon_meblevi_roboti.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("443F7547-3A93-438B-B6D5-7F5CAC0A3E13"),
                Title = "Доставка",
                IconFilename = "category_icon_dostavka.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("B1423856-84B3-49AD-9FF1-57FD45E2D8D4"),
                ParentId = new Guid("443F7547-3A93-438B-B6D5-7F5CAC0A3E13"),
                Title = "Кур'єрські послуги",
                IconFilename = "category_icon_kurerski_poslugi.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("2D2DC17A-ABFD-4E1C-AB88-B8DC7E72DFE8"),
                ParentId = new Guid("443F7547-3A93-438B-B6D5-7F5CAC0A3E13"),
                Title = "Транспортні та складські послуги",
                IconFilename = "category_icon_transportni_skladski_poslugi.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("E08A3DC0-C504-45EE-B5DB-FD20C60C5DD4"),
                Title = "Фріланс",
                IconFilename = "category_icon_frilans.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("09696C51-D66A-4E9C-A830-EC4518419B1F"),
                ParentId = new Guid("E08A3DC0-C504-45EE-B5DB-FD20C60C5DD4"),
                Title = "Робота в Інтернеті",
                IconFilename = "category_icon_robota_v_interneti.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("00B3CC7C-7F0E-4061-A7E7-EEC8E8D98972"),
                ParentId = new Guid("E08A3DC0-C504-45EE-B5DB-FD20C60C5DD4"),
                Title = "Розробка сайтів та додатків",
                IconFilename = "category_icon_rozrobka_saitiv_i_dodtkiv.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("1ECB5AD5-A310-498A-B354-3DD515B665DD"),
                ParentId = new Guid("E08A3DC0-C504-45EE-B5DB-FD20C60C5DD4"),
                Title = "Дизайн",
                IconFilename = "category_icon_design.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("E6F62BE5-4676-41F6-91CC-B4F8B035503D"),
                ParentId = new Guid("E08A3DC0-C504-45EE-B5DB-FD20C60C5DD4"),
                Title = "Реклама в Інтернеті",
                IconFilename = "category_icon_reklama_v_interneti.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("17AD73DB-4FD7-4DD1-A26A-B049A69A1606"),
                Title = "Викладачі",
                IconFilename = "category_icon_vikladachi.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("104DDA7E-6050-4A3B-B58C-64BA8F77CD20"),
                ParentId = new Guid("17AD73DB-4FD7-4DD1-A26A-B049A69A1606"),
                Title = "Послуги репетиторів",
                IconFilename = "category_icon_poslugi_repetitoriv.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("1252DB5F-D58B-4DBF-9F27-AADFA481F559"),
                ParentId = new Guid("17AD73DB-4FD7-4DD1-A26A-B049A69A1606"),
                Title = "Послуги тренерів",
                IconFilename = "category_icon_poslugi_treneriv.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("0AFC549D-C57C-48E5-AA35-DE0000BB7179"),
                ParentId = new Guid("17AD73DB-4FD7-4DD1-A26A-B049A69A1606"),
                Title = "Бюро перекладів",
                IconFilename = "category_icon_buro_perekladiv.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("C9A09EE1-56B8-43F0-9F2A-51B1F05B8A3E"),
                Title = "Бізнес",
                IconFilename = "category_icon_bisnes.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("24456E3A-5C01-4E14-9D99-7277C9676F08"),
                ParentId = new Guid("C9A09EE1-56B8-43F0-9F2A-51B1F05B8A3E"),
                Title = "Ділові послуги",
                IconFilename = "category_icon_dilovi_poslugi.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("8D894F67-5F26-43A6-8984-5FDD6628D7FA"),
                Title = "Iнше"
            },
            new CategoryOfCategories
            {
                Id = new Guid("3ED80317-E242-4804-AFDF-20DD8FFC1414"),
                ParentId = new Guid("8D894F67-5F26-43A6-8984-5FDD6628D7FA"),
                Title = "Волонтерська допомога",
                IconFilename = "category_icon_volonterska_dopomoga.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("36C0821A-9317-4456-AD19-8AA73A805453"),
                ParentId = new Guid("8D894F67-5F26-43A6-8984-5FDD6628D7FA"),
                Title = "Фото- і відео-послуги",
                IconFilename = "category_icon_photo_i_video.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("25BAFEEC-DA51-46E5-A160-9596E6AAD7B6"),
                ParentId = new Guid("8D894F67-5F26-43A6-8984-5FDD6628D7FA"),
                Title = "Організація свят",
                IconFilename = "category_icon_organizacia_sviat.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("39196572-1E31-4CDD-BCEE-B42FD0922DD4"),
                ParentId = new Guid("8D894F67-5F26-43A6-8984-5FDD6628D7FA"),
                Title = "Послуги краси і здоров'я",
                IconFilename = "category_icon_poslugi_krasi_i_zdorovia.svg"
            },
            new CategoryOfCategories
            {
                Id = new Guid("8183DB09-7CFE-4017-89B9-6F40F45119EE"),
                ParentId = new Guid("8D894F67-5F26-43A6-8984-5FDD6628D7FA"),
                Title = "Ремонт авто",
                IconFilename = "category_icon_remont_avto.svg"
            }
        );

        builder.Entity<DataTemplate>().HasData(
            new DataTemplate
            {
                Id = new Guid("E8D111B8-21A3-445F-A090-CC07DBDAD3A3"),
                EstimatedCost = 700
            },
            new DataTemplate
            {
                Id = new Guid("DF91E5AF-5663-420D-AA49-3C3B7E41F6A0"),
                EstimatedCost = 400
            },
            new DataTemplate
            {
                Id = new Guid("469609A2-2435-4BDC-938A-BA2441F8D72A"),
                EstimatedCost = 460
            }
        );

        builder.Entity<CategoryOfTasks>().HasData(
            new CategoryOfTasks
            {
                Id = new Guid("6782B015-0AED-4BFA-A773-54984CE407E8"),
                ParentId = new Guid("EF5ED6A2-3FDA-4307-97A5-E6600D8E1C52"),
                Title = "Столяр",
                OrderAddressDataTemplateId = DataTemplateEntityConfiguration.OrderAddressSimple,
                PaymentDataTemplateId = new Guid("E8D111B8-21A3-445F-A090-CC07DBDAD3A3")
            },
            new CategoryOfTasks
            {
                Id = new Guid("EDAE1870-34C2-4663-AE76-A1E8BC749FFD"),
                ParentId = new Guid("2D2DC17A-ABFD-4E1C-AB88-B8DC7E72DFE8"),
                Title = "Вантажні перевезення",
                OrderAddressDataTemplateId = DataTemplateEntityConfiguration.OrderAddressFromWhere,
                PaymentDataTemplateId = new Guid("DF91E5AF-5663-420D-AA49-3C3B7E41F6A0")
            },
            new CategoryOfTasks
            {
                Id = new Guid("9F979A5F-2C4D-4D84-8D56-C09DEA3E286E"),
                ParentId = new Guid("BA194614-FDC8-4830-BDE0-647532E7DA46"),
                Title = "Прибирання квартир",
                OrderAddressDataTemplateId = DataTemplateEntityConfiguration.OrderAddressSimple,
                PaymentDataTemplateId = new Guid("469609A2-2435-4BDC-938A-BA2441F8D72A")
            }
        );

        builder.Entity<DataTemplateItem>().HasData(
            new DataTemplateItem
            {
                Id = new Guid("2316A1B8-87AA-43F8-9AD0-76142F670218"),
                Title = "Вантажники",
                Type = DataTemplateType.SingleSelection,
                DataTemplateId = new Guid("DF91E5AF-5663-420D-AA49-3C3B7E41F6A0")
            },
            new DataTemplateItem
            {
                Id = new Guid("EFD1F2BD-AB09-4C95-A9AF-ECFFB2F9F8D0"),
                Title = "Наявність робочого ліфта",
                Type = DataTemplateType.SingleSelection,
                DataTemplateId = new Guid("DF91E5AF-5663-420D-AA49-3C3B7E41F6A0")
            },
            new DataTemplateItem
            {
                Id = new Guid("CA3B3BF7-DA39-429A-AA96-2E30E661EDB8"),
                Title = "Тип авто",
                Type = DataTemplateType.SingleSelection,
                DataTemplateId = new Guid("DF91E5AF-5663-420D-AA49-3C3B7E41F6A0")
            },
            new DataTemplateItem
            {
                Id = new Guid("9449E87D-3556-462B-8F74-6BA125042930"),
                Title = "",
                Type = DataTemplateType.MultipleSelection,
                DataTemplateId = new Guid("469609A2-2435-4BDC-938A-BA2441F8D72A")
            }
        );

        builder.Entity<DataTemplateItemValue>().HasData(
            new DataTemplateItemValue
            {
                Id = new Guid("4D7B8671-51E9-4206-BF07-956D5572FCFB"),
                Value = "Мийка вікон",
                AddedMoney = 400,
                DataTemplateItemId = new Guid("9449E87D-3556-462B-8F74-6BA125042930")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("6260925C-306C-40B0-A1F6-04ABF762D861"),
                Value = "Мийка санвузла",
                AddedMoney = 200,
                DataTemplateItemId = new Guid("9449E87D-3556-462B-8F74-6BA125042930")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("C89187D6-2B98-49D2-B873-1D4DDDAC3488"),
                Value = "Мийка холодильника",
                AddedMoney = 200,
                DataTemplateItemId = new Guid("9449E87D-3556-462B-8F74-6BA125042930")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("90EE4EC2-3651-47DD-AB89-57FEFC2203B8"),
                Value = "не потрібні",
                AddedMoney = 0,
                DataTemplateItemId = new Guid("2316A1B8-87AA-43F8-9AD0-76142F670218")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("9A6E37A4-F4D2-420A-B2CC-75EB179E19DC"),
                Value = "1 вантажник",
                AddedMoney = 200,
                DataTemplateItemId = new Guid("2316A1B8-87AA-43F8-9AD0-76142F670218")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("D3E9CDB3-6B52-4B3A-9529-DFD245036684"),
                Value = "2 вантажника",
                AddedMoney = 400,
                DataTemplateItemId = new Guid("2316A1B8-87AA-43F8-9AD0-76142F670218")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("A54BC5B6-1A5E-48FD-ACA8-2DD306BC8237"),
                Value = "3 вантажника",
                AddedMoney = 600,
                DataTemplateItemId = new Guid("2316A1B8-87AA-43F8-9AD0-76142F670218")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("606637AC-7DEA-4B70-BCDC-6439637D9E3C"),
                Value = "є пасажирський",
                AddedMoney = 0,
                DataTemplateItemId = new Guid("EFD1F2BD-AB09-4C95-A9AF-ECFFB2F9F8D0")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("7646766D-68C2-4619-9572-26BD2FE3682E"),
                Value = "є вантажний",
                AddedMoney = 0,
                DataTemplateItemId = new Guid("EFD1F2BD-AB09-4C95-A9AF-ECFFB2F9F8D0")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("27EBADB1-8FA4-4A5D-94FB-B7E40A89C2CB"),
                Value = "немає ліфта (1-5 поверх)",
                AddedMoney = 400,
                DataTemplateItemId = new Guid("EFD1F2BD-AB09-4C95-A9AF-ECFFB2F9F8D0")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("3239D382-7026-467C-84EB-D4CC8C4D8264"),
                Value = "немає ліфта (5+ поверхів)",
                AddedMoney = 600,
                DataTemplateItemId = new Guid("EFD1F2BD-AB09-4C95-A9AF-ECFFB2F9F8D0")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("C83A6CA6-68E0-4928-914C-7D530DA72164"),
                Value = "Мікроавтобус (до 2 тонн)",
                AddedMoney = 0,
                DataTemplateItemId = new Guid("CA3B3BF7-DA39-429A-AA96-2E30E661EDB8")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("920DB9C4-7CA3-4FD7-A624-6FA561C8C8FE"),
                Value = "Газель (до 1.5 тонн)",
                AddedMoney = 100,
                DataTemplateItemId = new Guid("CA3B3BF7-DA39-429A-AA96-2E30E661EDB8")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("60CF5C19-1B01-4B78-BE95-48F2493C2371"),
                Value = "ЗІЛ (до 5.5 тонн)",
                AddedMoney = 1000,
                DataTemplateItemId = new Guid("CA3B3BF7-DA39-429A-AA96-2E30E661EDB8")
            },
            new DataTemplateItemValue
            {
                Id = new Guid("0AD8CAC6-B5BD-43B8-A066-E33B654D49DE"),
                Value = "КАМАЗ (до 13 тонн)",
                AddedMoney = 2000,
                DataTemplateItemId = new Guid("CA3B3BF7-DA39-429A-AA96-2E30E661EDB8")
            }
        );
    }
}