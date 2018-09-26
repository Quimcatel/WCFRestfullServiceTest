using System;
using System.Configuration;
using System.Timers;

namespace Services
{
    public class InvoiceService : IInvoiceService
    {
        //TODO: falta configurar
        //private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(typeof(string));

        //TODO: dado el comportamiento de los servicios, el valor seteado en el webconfig deberia guardarse en un fichero (o BBDD) en lugar de una variable
        //ya que esta se reinicializa a cada llamada y el comportamiento de ir mostrando un valor cada vez más pequeño no se dará nunca.
        //una vez implementado deberíamos cambiar algunas comparaciones para el correcto funcionamiento de la aplicación.
        int _contador = int.Parse(ConfigurationManager.AppSettings["counterValue"]);

        System.Timers.Timer unTimer = new System.Timers.Timer();

        public string GetCounterValue()
        {
            //TODO: implementar log4net
            //LOGGER.Debug("GetCounterValue");
            try
            {
                string _result = "0";

                if (_contador == int.Parse(ConfigurationManager.AppSettings["counterValue"]))
                {
                    unTimer.Elapsed += new ElapsedEventHandler(countDown);
                    unTimer.Interval = 1000;
                    unTimer.Enabled = true;
                    unTimer.Start();

                    return string.Format("Faltan {0} segundos para llegar a 0.", _contador);
                }
                else
                {
                    //bool _result = int.TryParse(_contador, out _number);

                    //if (_result)
                    if (!String.IsNullOrWhiteSpace(_contador.ToString()) && _contador >= 0)
                        _result = string.Format("Faltan {0} segundos para llegar a 0.", _contador);
                }

                return _result;
            }
            catch (Exception ex)
            {
                //TODO: implementar log4net
                //LOGGER.Error("ERROR in GetCounterValue: " + ex.Message);
                throw ex;
            }
        }

        //public InvoiceDto[] GetAllInvoices()
        //{
        //    return new[] { new InvoiceDto(1, "receiver1"), new InvoiceDto(2, "receiver2") };
        //    //private int _currentValue = ConfigurationManager.AppSettings["counterValue"];
        //}

        private void countDown(object source, ElapsedEventArgs e)
        {
            if (_contador > 0)
                _contador--;
            else
                unTimer.Stop();
        }
    }
}
