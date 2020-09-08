using System.Collections.Generic;
using System.Data;
using UFO.Utilities;

namespace UFO
{
    
    public class NationalitiesViewModel : ListViewModelBase
    {
        #region Member Data

        private ListView view;
        private List<Nationality> items;
        private AppObjectBase[] itemsArray;
        private DbWorker dbWorker;
        //private IDataAccessService das = null;
        
        #endregion


        #region Constructor

        public NationalitiesViewModel(  ListView view,
                                        //List<AccessPoint> items,
                                        AppObjectBase[] selectedItems)
                                        //IDataAccessService das)
            : base(view)
        {
            this.view = view;
            base.Title = "Гражданство";
            this.dbWorker = new DbWorker();
            this.items = this.getItems();
            this.itemsArray = this.items.ToArray();
            base.ItemProperties.Add("IsChecked");
            base.ItemProperties.Add("Name");
            base.ItemProperties.Add("Id");            

            base.CheckItems(selectedItems);
            base.SubscribeOnItemChanged();
        }

        #endregion

        private List<Nationality> getItems()
        {
            /*
            List<Nationality> list = new List<Nationality>();
            list.Add(new Nationality() { Name = "АВСТРАЛИЯ", Id = "AUS" });
            list.Add(new Nationality() { Name = "АВСТРИЯ", Id = "AUT" });
            list.Add(new Nationality() { Name = "АЗЕРБАЙДЖАН", Id = "AZE" });
            list.Add(new Nationality() { Name = "АЛБАНИЯ", Id = "ALB" });
            list.Add(new Nationality() { Name = "АЛЖИР", Id = "DZA" });
            list.Add(new Nationality() { Name = "АМЕРИКАНСКОЕ САМОА", Id = "ASM" });
            list.Add(new Nationality() { Name = "АНГОЛА", Id = "AGO" });
            list.Add(new Nationality() { Name = "АНГИЛЬЯ", Id = "AIA" });
            list.Add(new Nationality() { Name = "АНДОРРА", Id = "AND" });
            list.Add(new Nationality() { Name = "АНТАРКТИДА", Id = "ATA" });
            list.Add(new Nationality() { Name = "АНТИГУА И БАРБУДА", Id = "ATG" });
            list.Add(new Nationality() { Name = "АРГЕНТИНА", Id = "ARG" });
            list.Add(new Nationality() { Name = "АРМЕНИЯ", Id = "ARM" });
            list.Add(new Nationality() { Name = "АРУБА", Id = "ABW" });
            list.Add(new Nationality() { Name = "АФГАНИСТАН", Id = "AFG" });
            list.Add(new Nationality() { Name = "БАГАМЫ", Id = "BHS" });
            list.Add(new Nationality() { Name = "БАНГЛАДЕШ", Id = "BGD" });
            list.Add(new Nationality() { Name = "БАРБАДОС", Id = "BRB" });
            list.Add(new Nationality() { Name = "БАХРЕЙН", Id = "BHR" });
            list.Add(new Nationality() { Name = "БЕЛАРУСЬ", Id = "BLR" });
            list.Add(new Nationality() { Name = "БЕЛИЗ", Id = "BLZ" });
            list.Add(new Nationality() { Name = "БЕЛЬГИЯ", Id = "BEL" });
            list.Add(new Nationality() { Name = "БЕНИН", Id = "BEN" });
            list.Add(new Nationality() { Name = "БЕРМУДЫ", Id = "BMU" });
            list.Add(new Nationality() { Name = "БОЛГАРИЯ", Id = "BGR" });
            list.Add(new Nationality() { Name = "БОЛИВИЯ, МНОГОНАЦИОНАЛЬНОЕ ГОСУДАРСТВО", Id = "BOL" });
            list.Add(new Nationality() { Name = "БОТСВАНА", Id = "BWA" });
            list.Add(new Nationality() { Name = "БРАЗИЛИЯ", Id = "BRA" });
            list.Add(new Nationality() { Name = "БРИТАНСКАЯ ТЕРРИТОРИЯ В ИНДИЙСКОМ ОКЕАНЕ", Id = "IOT" });
            list.Add(new Nationality() { Name = "БРУНЕЙ-ДАРУССАЛАМ", Id = "BRN" });
            list.Add(new Nationality() { Name = "БУРКИНА-ФАСО", Id = "BFA" });
            list.Add(new Nationality() { Name = "БУРУНДИ", Id = "BDI" });
            list.Add(new Nationality() { Name = "БУТАН", Id = "BTN" });
            list.Add(new Nationality() { Name = "ВАНУАТУ", Id = "VUT" });
            list.Add(new Nationality() { Name = "ПАПСКИЙ ПРЕСТОЛ (ГОСУДАРСТВО-ГОРОД ВАТИКАН)", Id = "VAT" });
            list.Add(new Nationality() { Name = "ВЕНГРИЯ", Id = "HUN" });
            list.Add(new Nationality() { Name = "ВЕНЕСУЭЛА БОЛИВАРИАНСКАЯ РЕСПУБЛИКА", Id = "VEN" });
            list.Add(new Nationality() { Name = "ВИРГИНСКИЕ ОСТРОВА (БРИТАНСКИЕ)", Id = "VGB" });
            list.Add(new Nationality() { Name = "ВИРГИНСКИЕ ОСТРОВА (США)", Id = "VIR" });
            list.Add(new Nationality() { Name = "ТИМОР-ЛЕСТЕ", Id = "TLS" });
            list.Add(new Nationality() { Name = "ВЬЕТНАМ", Id = "VNM" });
            list.Add(new Nationality() { Name = "ГАБОН", Id = "GAB" });
            list.Add(new Nationality() { Name = "ГАИТИ", Id = "HTI" });
            list.Add(new Nationality() { Name = "ГАЙАНА", Id = "GUY" });
            list.Add(new Nationality() { Name = "ГАМБИЯ", Id = "GMB" });
            list.Add(new Nationality() { Name = "ГАНА", Id = "GHA" });
            list.Add(new Nationality() { Name = "ГВАДЕЛУПА", Id = "GLP" });
            list.Add(new Nationality() { Name = "ГВАТЕМАЛА", Id = "GTM" });
            list.Add(new Nationality() { Name = "ГВИНЕЯ", Id = "GIN" });
            list.Add(new Nationality() { Name = "ГВИНЕЯ-БИСАУ", Id = "GNB" });
            list.Add(new Nationality() { Name = "ГЕРМАНИЯ", Id = "DEU" });
            list.Add(new Nationality() { Name = "ГИБРАЛТАР", Id = "GIB" });
            list.Add(new Nationality() { Name = "ГОНДУРАС", Id = "HND" });
            list.Add(new Nationality() { Name = "ГОНКОНГ", Id = "HKG" });
            list.Add(new Nationality() { Name = "ГРЕНАДА", Id = "GRD" });
            list.Add(new Nationality() { Name = "ГРЕНЛАНДИЯ", Id = "GRL" });
            list.Add(new Nationality() { Name = "ГРЕЦИЯ", Id = "GRC" });
            list.Add(new Nationality() { Name = "ГРУЗИЯ", Id = "GEO" });
            list.Add(new Nationality() { Name = "ГУАМ", Id = "GUM" });
            list.Add(new Nationality() { Name = "ДАНИЯ", Id = "DNK" });
            list.Add(new Nationality() { Name = "ДЖИБУТИ", Id = "DJI" });
            list.Add(new Nationality() { Name = "ДОМИНИКА", Id = "DMA" });
            list.Add(new Nationality() { Name = "ДОМИНИКАНСКАЯ РЕСПУБЛИКА", Id = "DOM" });
            list.Add(new Nationality() { Name = "ЕГИПЕТ", Id = "EGY" });
            list.Add(new Nationality() { Name = "КОНГО, ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА (ЗАИР)", Id = "COD" });
            list.Add(new Nationality() { Name = "ЗАМБИЯ", Id = "ZMB" });
            list.Add(new Nationality() { Name = "ЗАПАДНАЯ САХАРА", Id = "ESH" });
            list.Add(new Nationality() { Name = "ЗИМБАБВЕ", Id = "ZWE" });
            list.Add(new Nationality() { Name = "ИЗРАИЛЬ", Id = "ISR" });
            list.Add(new Nationality() { Name = "ИНДОНЕЗИЯ", Id = "IDN" });
            list.Add(new Nationality() { Name = "ИНДИЯ", Id = "IND" });
            list.Add(new Nationality() { Name = "ИОРДАНИЯ", Id = "JOR" });
            list.Add(new Nationality() { Name = "ИРАК", Id = "IRQ" });
            list.Add(new Nationality() { Name = "ИРАН, ИСЛАМСКАЯ РЕСПУБЛИКА", Id = "IRN" });
            list.Add(new Nationality() { Name = "ИРЛАНДИЯ", Id = "IRL" });
            list.Add(new Nationality() { Name = "ИСЛАНДИЯ", Id = "ISL" });
            list.Add(new Nationality() { Name = "ИСПАНИЯ", Id = "ESP" });
            list.Add(new Nationality() { Name = "ИТАЛИЯ", Id = "ITA" });
            list.Add(new Nationality() { Name = "ЙЕМЕН", Id = "YEM" });
            list.Add(new Nationality() { Name = "КАБО-ВЕРДЕ", Id = "CPV" });
            list.Add(new Nationality() { Name = "КАЗАХСТАН", Id = "KAZ" });
            list.Add(new Nationality() { Name = "ОСТРОВА КАЙМАН", Id = "CYM" });
            list.Add(new Nationality() { Name = "КАМБОДЖА", Id = "KHM" });
            list.Add(new Nationality() { Name = "КАМЕРУН", Id = "CMR" });
            list.Add(new Nationality() { Name = "КАНАДА", Id = "CAN" });
            list.Add(new Nationality() { Name = "КАТАР", Id = "QAT" });
            list.Add(new Nationality() { Name = "КЕНИЯ", Id = "KEN" });
            list.Add(new Nationality() { Name = "КИПР", Id = "CYP" });
            list.Add(new Nationality() { Name = "КИРИБАТИ", Id = "KIR" });
            list.Add(new Nationality() { Name = "КИТАЙ", Id = "CHN" });
            list.Add(new Nationality() { Name = "КОКОСОВЫЕ (КИЛИНГ) ОСТРОВА", Id = "CCK" });
            list.Add(new Nationality() { Name = "КОЛУМБИЯ", Id = "COL" });
            list.Add(new Nationality() { Name = "КОМОРЫ", Id = "COM" });
            list.Add(new Nationality() { Name = "КОНГО", Id = "COG" });
            list.Add(new Nationality() { Name = "КОРЕЙСКАЯ НАРОДНО-ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА", Id = "PRK" });
            list.Add(new Nationality() { Name = "КОСТА-РИКА", Id = "CRI" });
            list.Add(new Nationality() { Name = "КОТ-Д-ИВУАР", Id = "CIV" });
            list.Add(new Nationality() { Name = "КУБА", Id = "CUB" });
            list.Add(new Nationality() { Name = "КУВЕЙТ", Id = "KWT" });
            list.Add(new Nationality() { Name = "КИРГИЗИЯ", Id = "KGZ" });
            list.Add(new Nationality() { Name = "ЛАОССКАЯ НАРОДНО-ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА", Id = "LAO" });
            list.Add(new Nationality() { Name = "ЛАТВИЯ", Id = "LVA" });
            list.Add(new Nationality() { Name = "ЛЕСОТО", Id = "LSO" });
            list.Add(new Nationality() { Name = "ЛИБЕРИЯ", Id = "LBR" });
            list.Add(new Nationality() { Name = "ЛИВАН", Id = "LBN" });
            list.Add(new Nationality() { Name = "ЛИВИЯ", Id = "LBY" });
            list.Add(new Nationality() { Name = "ЛИТВА", Id = "LTU" });
            list.Add(new Nationality() { Name = "ЛИХТЕНШТЕЙН", Id = "LIE" });
            list.Add(new Nationality() { Name = "ЛЮКСЕМБУРГ", Id = "LUX" });
            list.Add(new Nationality() { Name = "МАВРИКИЙ", Id = "MUS" });
            list.Add(new Nationality() { Name = "МАВРИТАНИЯ", Id = "MRT" });
            list.Add(new Nationality() { Name = "МАДАГАСКАР", Id = "MDG" });
            list.Add(new Nationality() { Name = "МАКАО", Id = "MAC" });
            list.Add(new Nationality() { Name = "МАЛАВИ", Id = "MWI" });
            list.Add(new Nationality() { Name = "МАЛАЙЗИЯ", Id = "MYS" });
            list.Add(new Nationality() { Name = "МАЛИ", Id = "MLI" });
            list.Add(new Nationality() { Name = "МАЛЫЕ ТИХООКЕАНСКИЕ ОТДАЛЕННЫЕ ОСТРОВА СОЕДИНЕННЫХ ШТАТОВ", Id = "UMI" });
            list.Add(new Nationality() { Name = "МАЛЬДИВЫ", Id = "MDV" });
            list.Add(new Nationality() { Name = "МАЛЬТА", Id = "MLT" });
            list.Add(new Nationality() { Name = "МАРОККО", Id = "MAR" });
            list.Add(new Nationality() { Name = "МАРТИНИКА", Id = "MTQ" });
            list.Add(new Nationality() { Name = "МАРШАЛЛОВЫ ОСТРОВА", Id = "MHL" });
            list.Add(new Nationality() { Name = "МЕКСИКА", Id = "MEX" });
            list.Add(new Nationality() { Name = "МОЗАМБИК", Id = "MOZ" });
            list.Add(new Nationality() { Name = "МОНАКО", Id = "MCO" });
            list.Add(new Nationality() { Name = "МОНГОЛИЯ", Id = "MNG" });
            list.Add(new Nationality() { Name = "МОНТСЕРРАТ", Id = "MSR" });
            list.Add(new Nationality() { Name = "МЬЯНМА", Id = "MMR" });
            list.Add(new Nationality() { Name = "НАМИБИЯ", Id = "NAM" });
            list.Add(new Nationality() { Name = "НАУРУ", Id = "NRU" });
            list.Add(new Nationality() { Name = "НЕПАЛ", Id = "NPL" });
            list.Add(new Nationality() { Name = "НИГЕР", Id = "NER" });
            list.Add(new Nationality() { Name = "НИГЕРИЯ", Id = "NGA" });
            list.Add(new Nationality() { Name = "НИДЕРЛАНДЫ", Id = "NLD" });
            list.Add(new Nationality() { Name = "НИКАРАГУА", Id = "NIC" });
            list.Add(new Nationality() { Name = "НИУЭ", Id = "NIU" });
            list.Add(new Nationality() { Name = "НОВАЯ ЗЕЛАНДИЯ", Id = "NZL" });
            list.Add(new Nationality() { Name = "НОВАЯ КАЛЕДОНИЯ", Id = "NCL" });
            list.Add(new Nationality() { Name = "НОРВЕГИЯ", Id = "NOR" });
            list.Add(new Nationality() { Name = "ТАНЗАНИЯ, ОБЪЕДИНЕННАЯ РЕСПУБЛИКА", Id = "TZA" });
            list.Add(new Nationality() { Name = "ОБЪЕДИНЕННЫЕ АРАБСКИЕ ЭМИРАТЫ", Id = "ARE" });
            list.Add(new Nationality() { Name = "ОМАН", Id = "OMN" });
            list.Add(new Nationality() { Name = "ОСТРОВ БУВЕ", Id = "BVT" });
            list.Add(new Nationality() { Name = "ОСТРОВ НОРФОЛК", Id = "NFK" });
            list.Add(new Nationality() { Name = "ОСТРОВ РОЖДЕСТВА", Id = "CXR" });
            list.Add(new Nationality() { Name = "СВЯТАЯ ЕЛЕНА", Id = "SHN" });
            list.Add(new Nationality() { Name = "ОСТРОВА КУКА", Id = "COK" });
            list.Add(new Nationality() { Name = "ОСТРОВА ТЕРКС И КАЙКОС", Id = "TCA" });
            list.Add(new Nationality() { Name = "УОЛЛИС И ФУТУНА", Id = "WLF" });
            list.Add(new Nationality() { Name = "ОСТРОВ ХЕРД И ОСТРОВА МАКДОНАЛЬД", Id = "HMD" });
            list.Add(new Nationality() { Name = "ШПИЦБЕРГЕН И ЯН МАЙЕН", Id = "SJM" });
            list.Add(new Nationality() { Name = "ПАКИСТАН", Id = "PAK" });
            list.Add(new Nationality() { Name = "ПАЛАУ", Id = "PLW" });
            list.Add(new Nationality() { Name = "ПАНАМА", Id = "PAN" });
            list.Add(new Nationality() { Name = "ПАПУА-НОВАЯ ГВИНЕЯ", Id = "PNG" });
            list.Add(new Nationality() { Name = "ПАРАГВАЙ", Id = "PRY" });
            list.Add(new Nationality() { Name = "ПЕРУ", Id = "PER" });
            list.Add(new Nationality() { Name = "ПИТКЕРН", Id = "PCN" });
            list.Add(new Nationality() { Name = "ПОЛЬША", Id = "POL" });
            list.Add(new Nationality() { Name = "ПОРТУГАЛИЯ", Id = "PRT" });
            list.Add(new Nationality() { Name = "ПУЭРТО-РИКО", Id = "PRI" });
            list.Add(new Nationality() { Name = "КОРЕЯ, РЕСПУБЛИКА", Id = "KOR" });
            list.Add(new Nationality() { Name = "МОЛДОВА, РЕСПУБЛИКА", Id = "MDA" });
            list.Add(new Nationality() { Name = "РЕЮНЬОН", Id = "REU" });
            list.Add(new Nationality() { Name = "РОССИЙСКАЯ ФЕДЕРАЦИЯ", Id = "RUS" });
            list.Add(new Nationality() { Name = "РУАНДА", Id = "RWA" });
            list.Add(new Nationality() { Name = "РУМЫНИЯ", Id = "ROU" });
            list.Add(new Nationality() { Name = "ЭЛЬ-САЛЬВАДОР", Id = "SLV" });
            list.Add(new Nationality() { Name = "САМОА", Id = "WSM" });
            list.Add(new Nationality() { Name = "САН-МАРИНО", Id = "SMR" });
            list.Add(new Nationality() { Name = "САН-ТОМЕ И ПРИНСИПИ", Id = "STP" });
            list.Add(new Nationality() { Name = "САУДОВСКАЯ АРАВИЯ", Id = "SAU" });
            list.Add(new Nationality() { Name = "СВАЗИЛЕНД", Id = "SWZ" });
            list.Add(new Nationality() { Name = "СЕВЕРНЫЕ МАРИАНСКИЕ ОСТРОВА", Id = "MNP" });
            list.Add(new Nationality() { Name = "СЕЙШЕЛЫ", Id = "SYC" });
            list.Add(new Nationality() { Name = "СЕНЕГАЛ", Id = "SEN" });
            list.Add(new Nationality() { Name = "СЕНТ-ПЬЕР И МИКЕЛОН", Id = "SPM" });
            list.Add(new Nationality() { Name = "СЕНТ-ВИНСЕНТ И ГРЕНАДИНЫ", Id = "VCT" });
            list.Add(new Nationality() { Name = "СЕНТ-КИТС И НЕВИС", Id = "KNA" });
            list.Add(new Nationality() { Name = "СЕНТ-ЛЮСИЯ", Id = "LCA" });
            list.Add(new Nationality() { Name = "СИНГАПУР", Id = "SGP" });
            list.Add(new Nationality() { Name = "СИРИЙСКАЯ АРАБСКАЯ РЕСПУБЛИКА", Id = "SYR" });
            list.Add(new Nationality() { Name = "СЛОВЕНИЯ", Id = "SVN" });
            list.Add(new Nationality() { Name = "СОЕДИНЕННОЕ КОРОЛЕВСТВО (ВЕЛИКОБРИТАНИЯ)", Id = "GBR" });
            list.Add(new Nationality() { Name = "СОЕДИНЕННЫЕ ШТАТЫ", Id = "USA" });
            list.Add(new Nationality() { Name = "СОМАЛИ", Id = "SOM" });
            list.Add(new Nationality() { Name = "СОЛОМОНОВЫ ОСТРОВА", Id = "SLB" });
            list.Add(new Nationality() { Name = "СУДАН", Id = "SDN" });
            list.Add(new Nationality() { Name = "СУРИНАМ", Id = "SUR" });
            list.Add(new Nationality() { Name = "СЬЕРРА-ЛЕОНЕ", Id = "SLE" });
            list.Add(new Nationality() { Name = "ТАДЖИКИСТАН", Id = "TJK" });
            list.Add(new Nationality() { Name = "ТАИЛАНД", Id = "THA" });
            list.Add(new Nationality() { Name = "ТАЙВАНЬ (КИТАЙ)", Id = "TWN" });
            list.Add(new Nationality() { Name = "ТОГО", Id = "TGO" });
            list.Add(new Nationality() { Name = "ТОКЕЛАУ", Id = "TKL" });
            list.Add(new Nationality() { Name = "ТОНГА", Id = "TON" });
            list.Add(new Nationality() { Name = "ТРИНИДАД И ТОБАГО", Id = "TTO" });
            list.Add(new Nationality() { Name = "ТУВАЛУ", Id = "TUV" });
            list.Add(new Nationality() { Name = "ТУНИС", Id = "TUN" });
            list.Add(new Nationality() { Name = "ТУРКМЕНИСТАН", Id = "TKM" });
            list.Add(new Nationality() { Name = "ТУРЦИЯ", Id = "TUR" });
            list.Add(new Nationality() { Name = "УГАНДА", Id = "UGA" });
            list.Add(new Nationality() { Name = "УЗБЕКИСТАН", Id = "UZB" });
            list.Add(new Nationality() { Name = "УКРАИНА", Id = "UKR" });
            list.Add(new Nationality() { Name = "УРУГВАЙ", Id = "URY" });
            list.Add(new Nationality() { Name = "ФАРЕРСКИЕ ОСТРОВА", Id = "FRO" });
            list.Add(new Nationality() { Name = "МИКРОНЕЗИЯ, ФЕДЕРАТИВНЫЕ ШТАТЫ", Id = "FSM" });
            list.Add(new Nationality() { Name = "ФИДЖИ", Id = "FJI" });
            list.Add(new Nationality() { Name = "ФИЛИППИНЫ", Id = "PHL" });
            list.Add(new Nationality() { Name = "ФИНЛЯНДИЯ", Id = "FIN" });
            list.Add(new Nationality() { Name = "ФОЛКЛЕНДСКИЕ ОСТРОВА (МАЛЬВИНСКИЕ)", Id = "FLK" });
            list.Add(new Nationality() { Name = "ФРАНЦИЯ", Id = "FRA" });
            list.Add(new Nationality() { Name = "ФРАНЦУЗСКАЯ ГВИАНА", Id = "GUF" });
            list.Add(new Nationality() { Name = "ФРАНЦУЗСКАЯ ПОЛИНЕЗИЯ", Id = "PYF" });
            list.Add(new Nationality() { Name = "ФРАНЦУЗСКИЕ ЮЖНЫЕ ТЕРРИТОРИИ", Id = "ATF" });
            list.Add(new Nationality() { Name = "ХОРВАТИЯ", Id = "HRV" });
            list.Add(new Nationality() { Name = "ЦЕНТРАЛЬНО-АФРИКАНСКАЯ РЕСПУБЛИКА", Id = "CAF" });
            list.Add(new Nationality() { Name = "ЧАД", Id = "TCD" });
            list.Add(new Nationality() { Name = "ЧИЛИ", Id = "CHL" });
            list.Add(new Nationality() { Name = "ШВЕЙЦАРИЯ", Id = "CHE" });
            list.Add(new Nationality() { Name = "ШВЕЦИЯ", Id = "SWE" });
            list.Add(new Nationality() { Name = "ШРИ-ЛАНКА", Id = "LKA" });
            list.Add(new Nationality() { Name = "ЭКВАДОР", Id = "ECU" });
            list.Add(new Nationality() { Name = "ЭКВАТОРИАЛЬНАЯ ГВИНЕЯ", Id = "GNQ" });
            list.Add(new Nationality() { Name = "ЭСТОНИЯ", Id = "EST" });
            list.Add(new Nationality() { Name = "ЭФИОПИЯ", Id = "ETH" });
            list.Add(new Nationality() { Name = "ЮЖНАЯ АФРИКА", Id = "ZAF" });
            list.Add(new Nationality() { Name = "ЯМАЙКА", Id = "JAM" });
            list.Add(new Nationality() { Name = "ЛБГ", Id = "XXX" });
            list.Add(new Nationality() { Name = "СЛОВАКИЯ", Id = "SVK" });
            list.Add(new Nationality() { Name = "ЧЕШСКАЯ РЕСПУБЛИКА", Id = "CZE" });
            list.Add(new Nationality() { Name = "РЕСПУБЛИКА МАКЕДОНИЯ", Id = "MKD" });
            list.Add(new Nationality() { Name = "БОСНИЯ И ГЕРЦЕГОВИНА", Id = "BIH" });
            list.Add(new Nationality() { Name = "ЭРИТРЕЯ", Id = "ERI" });
            list.Add(new Nationality() { Name = "МАЙОТТА", Id = "MYT" });
            list.Add(new Nationality() { Name = "ПАЛЕСТИНСКАЯ ТЕРРИТОРИЯ, ОККУПИРОВАННАЯ", Id = "PSE" });
            list.Add(new Nationality() { Name = "ЯПОНИЯ", Id = "JPN" });
            list.Add(new Nationality() { Name = "СЕРБИЯ", Id = "SRB" });
            list.Add(new Nationality() { Name = "ЧЕРНОГОРИЯ", Id = "MNE" });
            list.Add(new Nationality() { Name = "ОСТРОВ МЭН", Id = "IMN" });
            list.Add(new Nationality() { Name = "ЭЛАНДСКИЕ ОСТРОВА", Id = "ALA" });
            list.Add(new Nationality() { Name = "ЮЖНАЯ ДЖОРДЖИЯ И ЮЖНЫЕ САНДВИЧЕВЫ ОСТРОВА", Id = "SGS" });
            list.Add(new Nationality() { Name = "ДЖЕРСИ", Id = "JEY" });
            list.Add(new Nationality() { Name = "ГЕРНСИ", Id = "GGY" });
            list.Add(new Nationality() { Name = "АБХАЗИЯ", Id = "ABH" });
            list.Add(new Nationality() { Name = "ЮЖНАЯ ОСЕТИЯ", Id = "OST" });
            list.Add(new Nationality() { Name = "СЕН-БАРТЕЛЕМИ", Id = "BLM" });
            list.Add(new Nationality() { Name = "СЕН-МАРТЕН", Id = "MAF" });
            list.Add(new Nationality() { Name = "БОНЭЙР, СИНТ-ЭСТАТИУС И САБА", Id = "BES" });
            list.Add(new Nationality() { Name = "КЮРАСАО", Id = "CUW" });
            list.Add(new Nationality() { Name = "СЕН-МАРТЕН (НИДЕРЛАНДСКАЯ ЧАСТЬ)", Id = "SXM" });
            list.Add(new Nationality() { Name = "ЮЖНЫЙ СУДАН", Id = "SSD" });
            */

            List<Nationality> list = this.dbWorker.GetNationalities();
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            return list;

        }

        #region Properties
        public List<Nationality> Items
        {
            get { return this.items; }
            set
            {
                this.items = value;
                this.OnPropertyChanged("Items");
            }
        }
        #endregion

        #region ListViewModelBase
        public override AppObjectBase[] ItemsArray
        {
            get
            { 
                return this.itemsArray;
            }
        }
        public override DataTable ExportTable
        {
            get
            {
                HashSet<string> columsForExport = new HashSet<string>();
                columsForExport.Add("Name");                               
                DataTable table = ExportHelper.ListToDataTable(this.items, columsForExport);
                return table;
            }
        }

        #endregion

    }
}
