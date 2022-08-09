﻿
using indice.Edi.Serialization;

namespace EDI.Entities.Entities
{
    public class X12_315
    {
        public List<FunctionalGroup> Groups { get; set; }

        [EdiGroup]
        public class FunctionalGroup
        {

            [EdiValue("X(2)", Path = "GS/0", Description = "GS01 - Functional Identifier Code")]
            public string FunctionalIdentifierCode { get; set; }

            [EdiValue("X(15)", Path = "GS/1", Description = "GS02 - Application Sender's Code")]
            public string ApplicationSenderCode { get; set; }

            [EdiValue("X(15)", Path = "GS/2", Description = "GS03 - Application Receiver's Code")]
            public string ApplicationReceiverCode { get; set; }

            [EdiValue("9(8)", Path = "GS/3", Format = "yyyyMMdd", Description = "GS04 - Date")]
            [EdiValue("9(4)", Path = "GS/4", Format = "HHmm", Description = "GS05 - Time")]
            public DateTime Date { get; set; }

            [EdiValue("9(9)", Path = "GS/5", Format = "HHmm", Description = "GS06 - Group Control Number")]
            public int GroupControlNumber { get; set; }

            [EdiValue("X(2)", Path = "GS/6", Format = "HHmm", Description = "GS07 Responsible Agency Code")]
            public string AgencyCode { get; set; }

            [EdiValue("X(2)", Path = "GS/7", Format = "HHmm", Description = "GS08 Version / Release / Industry Identifier Code")]
            public string Version { get; set; }

            public List<Order> Orders { get; set; }


            [EdiValue("9(1)", Path = "GE/0", Description = "97 Number of Transaction Sets Included")]
            [EdiCount(EdiCountScope.Messages)]
            public int TransactionsCount { get; set; }

            [EdiValue("9(9)", Path = "GE/1", Description = "28 Group Control Number")]
            public int GroupTrailerControlNumber { get; set; }
        }

        [EdiMessage]
        public class Order
        {
            #region Header Trailer

            [EdiValue("X(3)", Path = "ST/0", Description = "ST01 - Transaction set ID code")]
            public string TransactionSetCode { get; set; }

            [EdiValue("X(9)", Path = "ST/1", Description = "ST02 - Transaction set control number")]
            public string TransactionSetControlNumber { get; set; }

            [EdiValue(Path = "SE/0", Description = "SE01 - Number of included segments")]
            [EdiCount(EdiCountScope.Segments)]
            public int SegmentsCounts { get; set; }

            [EdiValue("X(9)", Path = "SE/1", Description = "SE02 - Transaction set control number (same as ST02)")]
            public string TrailerTransactionSetControlNumber { get; set; }
            #endregion

            [EdiValue("X(2)", Path = "BEG/0", Description = "BEG01 - Trans. Set Purpose Code")]
            public string TransSetPurposeCode { get; set; }

            [EdiValue("X(2)", Path = "BEG/1", Description = "BEG02 - Purchase Order Type Code")]
            public string PurchaseOrderTypeCode { get; set; }

            [EdiValue(Path = "BEG/2", Description = "BEG03 - Purchase Order Number")]
            public string PurchaseOrderNumber { get; set; }

            [EdiValue("9(8)", Path = "BEG/4", Format = "yyyyMMdd", Description = "BEG05 - Purchase Order Date")]
            public string PurchaseOrderDate { get; set; }

            [EdiValue(Path = "CUR/0", Description = "CUR01 - Entity Identifier Code")]
            public string EntityIdentifierCode { get; set; }

            [EdiValue("X(3)", Path = "CUR/1", Description = "CUR02 - Currency Code")]
            public string CurrencyCode { get; set; }

            [EdiValue(Path = "REF/0", Description = "REF01 - Reference Identification Qualifier IA – Vendor Number assigned by Carhartt")]
            public string ReferenceIdentificationQualifier { get; set; }

            [EdiValue(Path = "REF/1", Description = "REF02 - Reference Identification")]
            public string ReferenceIdentification { get; set; }

            [EdiValue(Path = "FOB/4", Description = "FOB05 - Transportation Terms code")]
            public string TransportationTermscode { get; set; }

            [EdiValue(Path = "FOB/5", Description = "FOB06 - Code identifying type of location KL – Port of loading")]
            public string LocationQualifier { get; set; }

            [EdiValue("X(2)", Path = "ITD/0", Description = "ITD01 - Terms Type Code")]
            public string TermsTypeCode { get; set; }

            [EdiValue(Path = "ITD/1", Description = "ITD02 - Terms Basis Date Code")]
            public string TermsBasisDateCode { get; set; }

            [EdiValue(Path = "ITD/6", Description = "ITD07 - Terms Net Days")]
            public string TermsNetDays { get; set; }

            [EdiValue(Path = "TD5/3", Description = "TD504 - Transportation Method/Type Code")]
            public string TransportationMethod { get; set; }

            [EdiValue(Path = "MSG/0", Description = "MSG01 - Message Text")]
            public string OrderHeaderMessageText { get; set; }

            public List<Address> Addresses { get; set; }

            public List<OrderDetail> Items { get; set; }

            [EdiValue(Path = "AMT/1", Description = "AMT02 - Total amount of the Purchase Order")]
            public string TotalTransactionAmount { get; set; }

        }

        [EdiSegment, EdiSegmentGroup("PO1", SequenceEnd = "CTT")]
        public class OrderDetail
        {
            [EdiValue(Path = "PO1/0", Description = "PO101 - Order Line Number")]
            public string OrderLineNumber { get; set; }

            [EdiValue(Path = "PO1/1", Description = "PO102 - Quantity Ordered")]
            public decimal QuantityOrdered { get; set; }

            [EdiValue(Path = "PO1/2", Description = "PO103 - Unit Of Measurement")]
            public string UnitOfMeasurement { get; set; }

            [EdiValue(Path = "PO1/3", Description = "PO104 - Unit Price")]
            public decimal UnitPrice { get; set; }

            [EdiValue(Path = "PO1/8", Description = "PO109 - Buyer’s Part #.")]
            public string BuyersPartno { get; set; }

            [EdiValue(Path = "PO1/10", Description = "PO111 - Vendor’s Part #.")]
            public string VendorsPartno { get; set; }

            [EdiValue(Path = "PID/4", Description = "PID05 - Product Description")]
            public string ProductDescription { get; set; }

            [EdiValue(Path = "MEA/2", Description = "MEA03 - Measurement Value")]
            public decimal MeasurementValue { get; set; }

            [EdiCondition("018", Path = "DTM/0/0")]
            public DTM AvailableFromDate { get; set; }

            [EdiCondition("067", Path = "DTM/0/0")]
            public DTM ArrivalDate { get; set; }

            [EdiCondition("002", Path = "DTM/0/0")]
            public DTM DeliveryRequestedDate { get; set; }

            [EdiCondition("038", Path = "DTM/0/0")]
            public DTM ShipNoLaterDate { get; set; }

            [EdiValue(Path = "TC2/0", Description = "TC201 - Measurement Value")]
            public string TC201 { get; set; }

            public List<MSG> MSG { get; set; }

        }

        [EdiSegment, EdiSegmentGroup("N1", SequenceEnd = "PO1")]
        public class Address
        {

            [EdiValue(Path = "N1/0", Description = "N101 - Address Code")]
            public string AddressCode { get; set; }

            [EdiValue(Path = "N1/1", Description = "N102 - Address Name")]
            public string AddressName { get; set; }

            [EdiValue(Path = "N3/0", Description = "N301 - Address Information")]
            public string AddressInformation { get; set; }

            [EdiValue(Path = "N4/0", Description = "N401 - City Name")]
            public string CityName { get; set; }

            [EdiValue(Path = "N4/3", Description = "N404 - Country Code")]
            public string CountryCode { get; set; }

        }

        [EdiSegment, EdiPath("DTM")]
        public class DTM
        {

            [EdiValue(Path = "DTM/0", Description = "DTM01 - Date/Time Qualifier")]
            public string DateTimeQualifier { get; set; }

            [EdiValue("9(8)", Path = "DTM/1", Format = "yyyyMMdd", Description = "DTM02 - Date format =CCYYMMDD")]
            public DateTime Date { get; set; }
        }

        [EdiSegment, EdiPath("MSG")]
        public class MSG
        {

            [EdiValue(Path = "MSG/0", Description = "MSG01 - Message Text")]
            public string MessageText { get; set; }
        }
    }
}
