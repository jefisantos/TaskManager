<template>
  <div class="task-list-container">
    <h2>Lista de Tarefas</h2>
    <table>
      <thead>
        <tr>
          <th>Título</th>
          <th>Descrição</th>
          <th>Status</th>
          <th>Data de Criação</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="task in tasks" :key="task.id" :class="getStatusClass(task.status)">
          <td>{{ task.titulo }}</td>
          <td>{{ task.descricao }}</td>
          <td>
            <i :class="getStatusIcon(task.status)"></i> {{ task.status }}
          </td>
          <td>{{ new Date(task.datacriacao).toLocaleDateString() }}</td>
          <td>
            <button @click="editTask(task)">Editar</button>
            <button @click="deleteTask(task.id)">Excluir</button>
          </td>
        </tr>
      </tbody>
    </table>
    <TaskForm @taskUpdated="fetchTasks" :editTask="selectedTask" />
  </div>
</template>

<script>
import TaskForm from './TaskForm.vue';
import axios from 'axios';

export default {
  components: {
    TaskForm,
  },
  data() {
    return {
      tasks: [],
      selectedTask: null,
    };
  },
  methods: {
    async fetchTasks() {
      try {
        const response = await axios.get('http://localhost:5004/tasks');
        this.tasks = response.data;
      } catch (error) {
        console.error('Erro ao buscar tarefas:', error);
      }
    },
    async deleteTask(id) {
      try {
        await axios.delete(`http://localhost:5004/tasks/${id}`);
        this.fetchTasks();
      } catch (error) {
        console.error('Erro ao excluir tarefa:', error);
      }
    },
    editTask(task) {
      this.selectedTask = task;
    },
    getStatusClass(status) {
      if (status === 'Pendente') return 'status-pendente';
      if (status === 'Em progresso') return 'status-em-progresso';
      if (status === 'Concluído') return 'status-concluido';
      return '';
    },
    getStatusIcon(status) {
      if (status === 'Pendente') return 'fas fa-hourglass-start';
      if (status === 'Em progresso') return 'fas fa-spinner';
      if (status === 'Concluído') return 'fas fa-check-circle';
      return '';
    },
  },
  mounted() {
    this.fetchTasks();
  },
};
</script>

<style>
.task-list-container {
  max-width: 800px;
  margin: auto;
  text-align: center;
}

.task-list-container h2 {
  margin-bottom: 20px;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  padding: 10px;
  border: 1px solid #ddd;
}

.status-pendente {
  background-color: #ffcccc;
}
.status-em-progresso {
  background-color: #fff5cc;
}
.status-concluido {
  background-color: #ccffcc;
}

i.fas {
  margin-right: 8px;
}
</style>
