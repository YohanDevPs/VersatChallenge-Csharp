using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.enums
{
	internal enum ConceptType
	{
		[Description("Dinero actual"), ClassificationAsset("Activo Curriente")]
        CURRENT_MONEY,
        [Description("Cuentas para recibir"), ClassificationAsset("Activo Curriente")]
        BILL_TO_RECEIVE,
        [Description("Efectivos"), ClassificationAsset("Activo Curriente")]
        EFECTIVO,

        [Description("Propriedades"), ClassificationAsset("Activos fijos")]
        PROPERTY,
        [Description("Equipos"), ClassificationAsset("Activos fijos")]
        TEAM,
        [Description("Activos diferidos"), ClassificationAsset("Activos fijos")]
        DEFERRED_ASSETS,

        [Description("Impuesto"), ClassificationAsset("Passivos currientes")]
        TAX,
        [Description("Factura para pagar"), ClassificationAsset("Passivos currientes")]
        BILL_TO_PAY,
        [Description("Provisión de reserva"), ClassificationAsset("Passivos currientes")]
        RESERVE_PROVISION,

        [Description("Bonificaciones"), ClassificationAsset("Passivos a largo plazo")]
        BONUSES,
        [Description("Arrendamientos financieros"), ClassificationAsset("Passivos a largo plazo")]
        FINANCE_LEASES,
        [Description("Préstamo a largo plazo"), ClassificationAsset("Passivos a largo plazo")]
        LONG_TERM_LOAN
	}
}
