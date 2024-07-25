namespace SMSV_mongo2.Models
{
    public class DatabaseSettings 
    {
        public string? Server { get; set; } 
        public string? Database { get; set; }
        public string? CollectionAlertas { get; set; }

        public string? CollectionPacientes { get; set; }

        public string? CollectionMembresias { get; set; }

        public string? CollectionPaquetes { get; set; }
        public string? CollectionClientes { get; set; }

        public string? CollectionMonitorSignos { get; set; }

        public string? CollectionMonitor_registrados { get; set; }

        public string? CollectionPadecimientos { get; set; }
        public string? CollectionReporteFallas { get; set; }

    }


}
