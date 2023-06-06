using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class IngresosBLL
{
    private Context _context;

    public IngresosBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int IngresoId)
    {
        return _context.Ingresos.Any(i => i.IngresoId == IngresoId);
    }

    public bool Crear(Ingresos ingresos)
    {
        _context.Ingresos.Add(ingresos);
        int creado = _context.SaveChanges();
        _context.Entry(ingresos).State = EntityState.Detached;
        return creado > 0;
    }

    public bool Modificar(Ingresos ingresos)
    {
        _context.Update(ingresos);
        int modificado = _context.SaveChanges();
        _context.Entry(ingresos).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Ingresos ingresos)
    {
        if(!Existe(ingresos.IngresoId))
        {
            return Crear(ingresos);
        }
        else
        {
            return Modificar(ingresos);
        }
    }

    public bool Eliminar(Ingresos ingresos)
    {
        _context.Ingresos.Remove(ingresos);
        int eliminado = _context.SaveChanges();
        _context.Entry(ingresos).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Ingresos? Buscar(int IngresoId)
    {
        return _context.Ingresos.AsNoTracking().SingleOrDefault(i => i.IngresoId == IngresoId);
    }

    public List<Ingresos> Listar(Expression<Func<Ingresos, bool>> Criterio)
    {
        return _context.Ingresos.Where(Criterio).AsNoTracking().ToList();
    }

}