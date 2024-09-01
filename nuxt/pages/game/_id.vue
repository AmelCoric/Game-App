<template>
    <div v-if="game">
      <h1>{{ game.naslov }}</h1>
      <img :src="game.imageUrl" alt="Game Image" />
      <p>{{ game.opis }}</p>
      <p>
      Category:
      <span v-if="game.categories && game.categories.length">
        <span v-for="(category, index) in game.categories" :key="category.id">
          {{ category.ime }}
          
          <span v-if="index < game.categories.length - 1">, </span>
        </span>
      </span>
      <span v-else>Nema kategorije</span>
      
    </p>
      <button @click="deleteGame(game.id)">Delete</button>
      <button @click="editGame(game.id)">Edit</button>
    </div>
  </template>
  
  <script>
  export default {
    async asyncData({ params, store }) {
      const game = store.state.games.find((g) => g.id === parseInt(params.id));
      if (!game) {
        await store.dispatch('fetchGames');
      }
      return { game: store.state.games.find((g) => g.id === parseInt(params.id)) };
    },
    computed: {
      category() {
        return this.$store.state.categories.find((cat) => cat.id === this.game.categoryId);
      },
    },
    methods: {
    
      editGame(gameId) {
      
      this.$router.push(`/game/edit/${gameId}`);
    },
    async deleteGame(gameid) {
      
      await this.$store.dispatch('deleteGame', gameid);
    },
  },
  };
  </script>
  