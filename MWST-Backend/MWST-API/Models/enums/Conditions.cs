using System;
using System.Collections;

namespace enums
{
    public enum Condition{
        Cita,
        Recepcion,
        Apertura,
        EsperarTurnoDiagnostico,
        DiagnosticoCotizacion,
        Autorizacion,
        Servicio,
        ControlCalidad,
        Liquidacion,
        Prefactura,
        Factura,
        Entrega,
        Seguimiento
    }
}
/*
Conditions per service:
    Cita
    Recepcion
    Apertura
    Esperar turno para diagnostico
    Diagnostico
    Cotizacion
    Autorizacion
    Servicio
    Control de Calidad
    Liquidacion
    Pre factura
    Factura
    Entrega
    Seguimiento

Servicios / Tipos de trabajo
    PDI (Pre delivery inspection)
    Mantenimiento Periodico
    Reparacion
    others
*/