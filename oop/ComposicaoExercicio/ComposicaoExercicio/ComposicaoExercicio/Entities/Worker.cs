using System;
using ComposicaoExercicio.Entities.Enums;
// Namespace para List
using System.Collections.Generic;
using ComposicaoExercicio.Entities;

namespace ComposicaoExercicio.Entities
{
    class Worker
    {
        // Atributos
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        // List pois um trabalhador pode ter vários contratos.
        // Lista instanciada para não ser nula.
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        // Construtores
        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        // Métodos
        // 1. Adicionar contrato
        public void AddContract(HourContract contract)
        {
            // Adicionar à Lista de contratos recebe o contrato inputado
            Contracts.Add(contract);
        }
        // 2. Remover o contrato da lista de contratos do Worker
        public void RemoveContract(HourContract contract)
        {
            // Remover da Lista de contratos recebe o contrato inputado
            Contracts.Remove(contract);
        }
        // 3. Income: Descobrir quanto o worker ganhou num determinado ano-mes
        public double Income(int year, int month)
        {
            // O valor básico do Worker é no mínimo BaseSalary
            double sum = BaseSalary;
            // Agora percorre a lista de contratos, identificanos o mes-ano certo e adicionando os valores
            foreach (HourContract contract in Contracts)
            {   
                if(contract.Date.Year == year && contract.Date.Month == month)
                {

                    sum += contract.TotalValue();
                    Console.WriteLine(sum);
                }
            }
            return sum;
        }
    }
}

