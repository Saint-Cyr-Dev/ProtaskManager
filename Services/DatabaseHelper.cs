using SQLite;
using ProTaskMangers02.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskModel = ProTaskMangers02.Models.Task; // Alias for your Task model

namespace ProTaskManager.Services
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeDatabaseAsync().Wait();
        }

        private async System.Threading.Tasks.Task InitializeDatabaseAsync()
        {
            // Create tables if they do not exist
            await _database.CreateTableAsync<Project>().ConfigureAwait(false);
            await _database.CreateTableAsync<TaskModel>().ConfigureAwait(false);
            await _database.CreateTableAsync<Collaborator>().ConfigureAwait(false);
        }

        // Project CRUD operations
        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _database.Table<Project>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return await _database.Table<Project>().Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveProjectAsync(Project project)
        {
            if (project.Id != 0)
            {
                return await _database.UpdateAsync(project).ConfigureAwait(false);
            }
            else
            {
                return await _database.InsertAsync(project).ConfigureAwait(false);
            }
        }

        public async Task<int> DeleteProjectAsync(Project project)
        {
            return await _database.DeleteAsync(project).ConfigureAwait(false);
        }

        // Task CRUD operations
        public async Task<List<TaskModel>> GetTasksAsync()
        {
            return await _database.Table<TaskModel>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<TaskModel> GetTaskAsync(int id)
        {
            return await _database.Table<TaskModel>().Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveTaskAsync(TaskModel task)
        {
            if (task.Id != 0)
            {
                return await _database.UpdateAsync(task).ConfigureAwait(false);
            }
            else
            {
                return await _database.InsertAsync(task).ConfigureAwait(false);
            }
        }

        public async Task<int> DeleteTaskAsync(TaskModel task)
        {
            return await _database.DeleteAsync(task).ConfigureAwait(false);
        }

        // Collaborator CRUD operations
        public async Task<List<Collaborator>> GetCollaboratorsAsync()
        {
            return await _database.Table<Collaborator>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<Collaborator> GetCollaboratorAsync(int id)
        {
            return await _database.Table<Collaborator>().Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveCollaboratorAsync(Collaborator collaborator)
        {
            if (collaborator.Id != 0)
            {
                return await _database.UpdateAsync(collaborator).ConfigureAwait(false);
            }
            else
            {
                return await _database.InsertAsync(collaborator).ConfigureAwait(false);
            }
        }

        public async Task<int> DeleteCollaboratorAsync(Collaborator collaborator)
        {
            return await _database.DeleteAsync(collaborator).ConfigureAwait(false);
        }
    }
}
