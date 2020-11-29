using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW8Project.Models;

namespace HW8Project.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AssignmentDbContext _context;

        public AssignmentsController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public IActionResult Index()
        {
            var assignmentDbContext = _context.Assignments.Include(at => at.AssignmentTags)
                                                 .ThenInclude(t => t.Tag)
                                                 .Include(c => c.Class);

            return View(assignmentDbContext);
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            ViewData["ClassName"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["Tag"] = new SelectList(_context.Tags, "Id", "Name");

            ViewModel assign = new ViewModel();
            assign.Classes = _context.Classes;
            assign.Tags = _context.Tags;

            return View(assign);
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(ViewModel assign)
        {

            Assignment assignment = assign.Assignment;

            if(assign.SelectedTags != null)
            {
                int id = assign.SelectedTags.ElementAt(0);

                for(int i = 0; i < assign.SelectedTags.Count(); i++)
                {
                    AssignmentTag assignmentTag = new AssignmentTag {Assignment = assignment,
                                                                    AssignmentId = assign.Assignment.Id,
                                                                    Tag = _context.Tags.Single(n => n.Id == assign.SelectedTags.ElementAt(i)),
                                                                    TagId = assign.SelectedTags.ElementAt(i)};
                    _context.AssignmentTags.Add(assignmentTag);
                }
            }

            _context.Add(assignment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", assignment.ClassId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassId,Priority,DueDate,Title,Notes,IsComplete")] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", assignment.ClassId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
