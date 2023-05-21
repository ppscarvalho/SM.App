namespace SM.Integration.Application.ViewModels
{
    public class StateViewModel
    {
        public string? UF { get; set; }
        public string? Description { get; set; }

        public IEnumerable<StateViewModel> GetAllState()
        {
            var list = new List<StateViewModel> {
                new StateViewModel { UF = "AC", Description = "Acre" },
                new StateViewModel { UF = "AL", Description = "Alagoas" },
                new StateViewModel { UF = "AP", Description = "Amapá" },
                new StateViewModel { UF = "AM", Description = "Amazonas" },
                new StateViewModel { UF = "BA", Description = "Bahia" },
                new StateViewModel { UF = "CE", Description = "Ceará" },
                new StateViewModel { UF = "ES", Description = "Espírito Santo" },
                new StateViewModel { UF = "GO", Description = "Goiás" },
                new StateViewModel { UF = "MA", Description = "Maranhão" },
                new StateViewModel { UF = "MT", Description = "Mato Grosso" },
                new StateViewModel { UF = "MS", Description = "Mato Grosso do Sul" },
                new StateViewModel { UF = "MG", Description = "Minas Gerais" },
                new StateViewModel { UF = "PA", Description = "Pará" },
                new StateViewModel { UF = "PB", Description = "Paraíba" },
                new StateViewModel { UF = "PR", Description = "Paraná" },
                new StateViewModel { UF = "PE", Description = "Pernambuco" },
                new StateViewModel { UF = "PI", Description = "Piauí" },
                new StateViewModel { UF = "RJ", Description = "Rio de Janeiro" },
                new StateViewModel { UF = "RN", Description = "Rio Grande do Norte" },
                new StateViewModel { UF = "RS", Description = "Rio Grande do Sul" },
                new StateViewModel { UF = "RO", Description = "Rondônia" },
                new StateViewModel { UF = "RR", Description = "Roraima" },
                new StateViewModel { UF = "SC", Description = "Santa Catarina" },
                new StateViewModel { UF = "SP", Description = "São Paulo" },
                new StateViewModel { UF = "SE", Description = "Sergipe" },
                new StateViewModel { UF = "TO", Description = "Tocantins" },
                new StateViewModel { UF = "DF", Description = "Distrito Federal" },
            };

            return list;
        }
    }
}
