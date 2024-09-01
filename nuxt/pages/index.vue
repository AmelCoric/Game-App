<template>
  <div>
   
    <select v-model="selectedCategory" @change="filterGames">
      <option value="">All Categories</option>
      <option
        v-for="category in uniqueCategories"
        :key="category.id"
        :value="category.id"
      >
        {{ category.ime }}
      </option>
    </select>

    
    <div v-for="game in filteredGames" :key="game.id">
      <h2>{{ game.naslov }}</h2>
      <img :src="game.imageUrl" alt="Slika" />
      <p>{{ game.opis }}</p>
      
      <p>
        Category:
        <span v-if="game.categories.length">
          <span v-for="(category, index) in game.categories" :key="category.id">
            
            <span v-if="category.gameid === game.id">{{ category.ime }}</span>
           
            <span v-if="index < game.categories.length - 1">, </span>
          </span>
        </span>
        <span v-else>No categories available.</span>
      </p>
      <nuxt-link :to="`/game/${game.id}`">Detalji</nuxt-link>
      
      <button @click="deleteGame(game.id)">Delete</button>
      <nuxt-link to="/game/edit">Dodaj Novu igru</nuxt-link>
    </div>
    
  </div>
</template>

<script>
export default {
  data() {
    return {
      selectedCategory: '', 
    };
  },
  computed: {
    uniqueCategories() {
      
      const categories = [];
      this.$store.state.games.forEach((game) => {
        game.categories.forEach((category) => {
          if (!categories.some((cat) => cat.id === category.id)) {
            categories.push(category);
          }
        });
      });
      return categories;
    },
    filteredGames() {
     
      if (!this.selectedCategory) {
        return this.$store.state.games; 
      }
      return this.$store.state.games.filter((game) =>
        game.categories.some(
          (category) => category.id === parseInt(this.selectedCategory)
        )
      );
    },
  },
  methods: {
    filterGames() {
      
      this.$store.commit('setSelectedCategory', this.selectedCategory);
    },

    deleteGame(gameId) {
      
      this.$store.dispatch('deleteGame', gameId);
    },
  },
  created() {
    this.$store.dispatch('fetchGames'); 
  },
};
</script>

<style scoped>
.game-card {
  border: 1px solid #ddd;
  padding: 20px;
  margin-bottom: 20px;
}
</style>
