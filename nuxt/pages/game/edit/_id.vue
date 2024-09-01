<template>
    <div>
      <h1>{{ isEdit ? 'Edit Game' : 'Add New Game' }}</h1>
      <form @submit.prevent="submitForm">
        <label>Title:</label>
        <input type="text" v-model="game.naslov" required />
  
        <label>Description:</label>
        <textarea v-model="game.opis"></textarea>
  
        <label>Image URL:</label>
        <input type="url" v-model="game.imageUrl" />
  
        <label>Category:</label>
        <select v-model="game.categoryid" required>
          <option v-for="category in categories" :key="category.id" :value="category.id">
            {{ category.ime }}
          </option>
        </select>
        
        <button type="submit">{{ isEdit ? 'Update' : 'Add' }}</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        game: {
          ime: '',
          opis: '',
          imageUrl: '',
          categoryid: '',
        },
      };
    },
    computed: {
      isEdit() {
        return !!this.$route.params.id;
      },
      categories() {
        return this.$store.state.categories;
      },
    },
    async fetch() {
      await this.$store.dispatch('fetchCategories');
      if (this.isEdit) {
        const game = this.$store.state.games.find((g) => g.id === parseInt(this.$route.params.id));
        if (game) {
          this.game = { ...game };
        } else {
          await this.$store.dispatch('fetchGames');
          this.game = this.$store.state.games.find((g) => g.id === parseInt(this.$route.params.id)) || {};
        }
      }
    },
    methods: {
      submitForm() {
        if (this.isEdit) {
          this.$store.dispatch('updateGame', this.game);
        } else {
          this.$store.dispatch('addGame', this.game);
        }
        this.$router.push('/');
      },
    },
  };
  </script>
  