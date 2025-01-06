<template>
    <div>
      <h2>Formulário de Tarefa</h2>
      <form @submit.prevent="handleCreateTask" class="task-form">
        <input v-model="form.titulo" placeholder="Título" required class="input-box" @blur="validateTitulo" />
        <span v-if="errors.titulo" class="error-message">{{ errors.titulo }}</span>
        <textarea v-model="form.descricao" placeholder="Descrição" class="input-box"></textarea>
        <select v-model="form.status" class="input-box">
          <option value="Pendente">Pendente</option>
          <option value="Em progresso">Em progresso</option>
          <option value="Concluído">Concluído</option>
        </select>
        <button type="submit" class="btn-create">Criar Tarefa</button>
        <span v-if="errors.general" class="error-message">{{ errors.general }}</span>
      </form>
      <form @submit.prevent="handleUpdateTask" v-if="isEdit" class="task-form">
        <button type="submit" class="btn-update">Atualizar Tarefa</button>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    props: ['editTask'],
    data() {
      return {
        form: {
          id: null,
          titulo: '',
          descricao: '',
          status: 'Pendente',
        },
        isEdit: false,
        errors: {
          titulo: '',
          general: '',
        },
      };
    },
    watch: {
      editTask: {
        handler(newTask) {
          if (newTask) {
            this.isEdit = true;
            this.form = { ...newTask };
          }
        },
        immediate: true,
      },
    },
    methods: {
      validateTitulo() {
        if (!this.form.titulo) {
          this.errors.titulo = 'O título é obrigatório.';
        } else if (this.form.titulo.length < 3) {
          this.errors.titulo = 'O título deve ter pelo menos 3 caracteres.';
        } else if (this.form.titulo.length > 100) {
          this.errors.titulo = 'O título não pode ter mais de 100 caracteres.';
        } else {
          this.errors.titulo = '';
        }
      },
      async handleCreateTask() {
        this.validateTitulo();
        if (this.errors.titulo) {
          return;
        }
        try {
          const taskData = {
            titulo: this.form.titulo,
            descricao: this.form.descricao,
            status: this.form.status,
          };
  
          console.log('Dados do Formulário para Criação:', taskData);
  
          const response = await axios.post('http://localhost:5004/tasks', taskData, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
  
          console.log('Resposta do Servidor:', response);
          this.resetForm();
          this.$emit('taskUpdated');
        } catch (error) {
          console.error('Erro ao criar a tarefa:', error.response || error);
          if (error.response) {
            this.handleHttpError(error.response);
          }
        }
      },
      async handleUpdateTask() {
        this.validateTitulo();
        if (this.errors.titulo) {
          return;
        }
        try {
          const taskData = { ...this.form };
  
          console.log('Dados do Formulário para Atualização:', taskData);
  
          const response = await axios.put(`http://localhost:5004/tasks/${this.form.id}`, taskData, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
  
          console.log('Resposta do Servidor:', response);
          this.resetForm();
          this.$emit('taskUpdated');
        } catch (error) {
          console.error('Erro ao atualizar a tarefa:', error.response || error);
          if (error.response) {
            this.handleHttpError(error.response);
          }
        }
      },
      handleHttpError(response) {
        switch (response.status) {
          case 400:
            this.errors.general = 'Erro de Solicitação: Verifique os dados enviados.';
            break;
          case 404:
            this.errors.general = 'Erro: Recurso não encontrado.';
            break;
          case 500:
            this.errors.general = 'Erro Interno do Servidor: Por favor, tente novamente mais tarde.';
            break;
          default:
            this.errors.general = 'Erro: Algo deu errado. Por favor, tente novamente.';
        }
      },
      resetForm() {
        this.form = {
          id: null,
          titulo: '',
          descricao: '',
          status: 'Pendente',
        };
        this.errors.titulo = '';
        this.errors.general = '';
        this.isEdit = false;
      },
    },
  };
  </script>
  
  <style>
  .task-form {
    display: flex;
    flex-direction: column;
    gap: 10px;
    max-width: 400px;
    margin: auto;
  }
  
  .input-box {
    padding: 10px;
    font-size: 14px;
    border-radius: 4px;
    border: 1px solid #ccc;
  }
  
  .btn-create, .btn-update {
    padding: 8px 12px;
    font-size: 12px;
    color: #fff;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    margin: 10px auto; 
    width: fit-content;
  }
  
  .btn-create {
    background-color: #28a745;
  }
  
  .btn-update {
    background-color: #007bff; 
  }
  
  .error-message {
    color: red;
    font-size: 12px;
  }
  </style>
  