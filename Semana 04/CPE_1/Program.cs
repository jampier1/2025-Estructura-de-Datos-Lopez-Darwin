using System;

class Program
{
    // Vector de pacientes
    static Paciente[] pacientes = new Paciente[10];

    // Matriz de turnos: filas = pacientes, columnas = turnos
    static Turno[,] turnos = new Turno[10, 3];

    static int totalPacientes = 0;

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n=== AGENDA DE TURNOS DE PACIENTES ===");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Asignar turno");
            Console.WriteLine("3. Reporte de pacientes");
            Console.WriteLine("4. Reporte de turnos");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            opcion = int.Parse(Console.ReadLine()!);

            switch (opcion)
            {
                case 1: RegistrarPaciente(); break;
                case 2: AsignarTurno(); break;
                case 3: ReportePacientes(); break;
                case 4: ReporteTurnos(); break;
            }

        } while (opcion != 0);
    }

    static void RegistrarPaciente()
    {
        Paciente p = new Paciente();
        p.ID_Paciente = totalPacientes;

        Console.Write("Nombre: ");
        p.Nombre = Console.ReadLine()!;

        Console.Write("Cédula: ");
        p.Cedula = Console.ReadLine()!;

        pacientes[totalPacientes] = p;
        totalPacientes++;

        Console.WriteLine("Paciente registrado. ID: " + p.ID_Paciente);
    }

    static void AsignarTurno()
    {
        Console.Write("ID del paciente: ");
        int id = int.Parse(Console.ReadLine()!);

        for (int col = 0; col < 3; col++)
        {
            if (turnos[id, col].Hora == null)
            {
                turnos[id, col].ID_Paciente = id;

                Console.Write("Fecha (DD-MM-AAAA): ");
                turnos[id, col].Fecha = Console.ReadLine()!;

                Console.Write("Hora (24h HH:MM): ");
                turnos[id, col].Hora = Console.ReadLine()!;

                Console.WriteLine("Turno asignado.");
                return;
            }
        }

        Console.WriteLine("Límite de turnos alcanzado.");
    }

    static void ReportePacientes()
{
    int anchoId = 5;
    int anchoNombre = 25;
    int anchoCedula = 15;

    Console.WriteLine(
        "ID".PadRight(anchoId) +
        "Nombre".PadRight(anchoNombre) +
        "Cédula".PadLeft((anchoCedula + "Cédula".Length) / 2).PadRight(anchoCedula)
    );

    Console.WriteLine(new string('-', anchoId + anchoNombre + anchoCedula));

    for (int i = 0; i < totalPacientes; i++)
    {
        Console.WriteLine(
            pacientes[i].ID_Paciente.ToString().PadRight(anchoId) +
            pacientes[i].Nombre.PadRight(anchoNombre) +
            pacientes[i].Cedula.PadLeft((anchoCedula + pacientes[i].Cedula.Length) / 2)
                                .PadRight(anchoCedula)
        );
    }
}


    static void ReporteTurnos()
    {
        Console.WriteLine("\nID\tFecha\t\tHora");

        for (int f = 0; f < totalPacientes; f++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (turnos[f, c].Hora != null)
                {
                    Console.WriteLine(
                        turnos[f, c].ID_Paciente + "\t" +
                        turnos[f, c].Fecha + "\t" +
                        turnos[f, c].Hora
                    );
                }
            }
        }
    }
}
