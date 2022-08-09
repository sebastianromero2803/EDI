using indice.Edi;
using EDI.Core.Handlers;
using Microsoft.Extensions.Logging;
using EDI.Entities.Entities;
using EDI.Contracts.Repository;

namespace EDI.Core.V1
{
    public class EDICore
    {
        private readonly IEDIRepository _ediContext;
        private readonly ErrorHandler<X12_315> _errorHandler;
        private readonly ILogger<X12_315> _logger;

        public EDICore(IEDIRepository context, ILogger<X12_315> logger)
        {
            _ediContext = context;
            _logger = logger;
            _errorHandler = new ErrorHandler<X12_315>(logger);
        }

        public async string GetPurchaseOrder(string Id)
        {
            
        }

        public async string PostX12_350(string EDIFile)
        {
            var ediProcessed = ProcessEDIToJson(EDIFile);
            await _ediContext.AddAsync(ediProcessed);
        }

        public string ProcessEDIToJson(string inputEDIFilename) 
        {
            string inputEDIFilename2 = @"C:\Users\SEBASTIAN ROMERO\LeanTech\Backend Training\Projects\EDI\x12.850.edi";

            var grammar = EdiGrammar.NewX12();
            grammar.SetAdvice(
                segmentNameDelimiter: '*',
                dataElementSeparator: '*',
                componentDataElementSeparator: '>',
                segmentTerminator: '~',
                releaseCharacter: null,
                reserved: null,
                decimalMark: '.'
            );

            var po850 = default(X12_315);
            using (var stream = new StreamReader(inputEDIFilename))
            {
                po850 = new EdiSerializer().Deserialize<X12_315>(stream, grammar);

                var po850Json = Newtonsoft.Json.JsonConvert.SerializeObject(po850);
                return po850Json;
            }
        }
    }
}
