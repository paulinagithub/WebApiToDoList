﻿namespace WebApiToDo.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int IsCompleted { get; set; }
    }
}
