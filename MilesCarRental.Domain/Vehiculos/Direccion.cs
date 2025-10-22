using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Vehiculos;

public record Direccion(
    string Pais,
    string Departamento,
    string Ciudad,
    string Calle
);