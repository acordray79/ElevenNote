using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCat(CategoryCreate category)
        {
            var catEntity =
                new Category()
                {
                    CatID = category.CatID,
                    CatName = category.CatName,
                };

            using (var cat = new ApplicationDbContext())
            {
                cat.Category.Add(catEntity);
                return cat.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Category
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CatID = e.CatID,
                                    CatName = e.CatName
                                }
                        );

                return query.ToArray();
            }
        }
        public CategoryDetail GetCategoryById(int catID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Category
                        .Single(e => e.CatID == catID);
                return
                    new CategoryDetail
                    {
                        CatID = entity.CatID,
                        CatName = entity.CatName
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Category
                        .Single(e => e.CatID == model.CatID);
                entity.CatName = model.CatName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int catID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Category
                        .Single(e => e.CatID == catID);

                ctx.Category.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
