using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Studenti.Data;

namespace Studenti.Models
{
    public class SpecializareStudentPageModel : PageModel
    {
        public List<AtribuireSpecializare> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(StudentiContext context,
        Student student)
        {
            var allCategories = context.Specializare;
            var studCategories = new HashSet<int>(
            student.SpecializareStudenti.Select(c => c.ID));
            AssignedCategoryDataList = new List<AtribuireSpecializare>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AtribuireSpecializare
                {
                    IDSpecializare = cat.ID,
                    Specializare = cat.Denumire,
                    Atribuire = studCategories.Contains(cat.ID)

                });
            }
        }
        public void UpdateStudCategories(StudentiContext context,
        string[] selectedCategories, Student studToUpdate)
        {
            if (selectedCategories == null)
            {
                studToUpdate.SpecializareStudenti = new List<SpecializareStudent>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var studCategories = new HashSet<int>
            (studToUpdate.SpecializareStudenti.Select(c => c.Specializare.ID));
            foreach (var cat in context.Specializare)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!studCategories.Contains(cat.ID))
                    {
                        studToUpdate.SpecializareStudenti.Add(
                        new SpecializareStudent
                        {
                            StudentID = studToUpdate.ID,
                            IDSpecializare = cat.ID
                        });
                    }
                }
                else
                {
                    if (studCategories.Contains(cat.ID))
                    {
                        SpecializareStudent courseToRemove
                        = studToUpdate
                        .SpecializareStudenti
                        .SingleOrDefault(i => i.IDSpecializare == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}