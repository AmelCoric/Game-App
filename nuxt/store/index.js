// store/index.js
export const state = () => ({
  games: [],
  categories: [],
});

export const mutations = {
  setGames(state, games) {
    state.games = games;
  },
  addGame(state, game) {
    state.games.push(game);
  },
  updateGame(state, updatedGame) {
    const index = state.games.findIndex((game) => game.id === updatedGame.id);
    if (index !== -1) {
      state.games[index] = updatedGame;
    }
  },
  deleteGame(state, gameId) {
    state.games = state.games.filter((game) => game.id !== gameId);
  },
  setCategories(state, categories) {
    state.categories = categories;
  },
  addCategory(state, category) {
    state.categories.push(category);
  },
  setSelectedCategory(state, categoryId) {
    state.selectedCategory = categoryId;
  },
};

export const actions = {
  async fetchGames({ commit }) {
    try {
      const response = await this.$axios.$get('http://localhost:5242/api/game');
      commit('setGames', response);
    } catch (error) {
      console.error('Error fetching games:', error);
    }
  },
  async addGame({ commit }, game) {
    try {
      const response = await this.$axios.$post('http://localhost:5242/api/game', game);
      commit('addGame', response);
    } catch (error) {
      console.error('Error adding game:', error);
    }
  },
  async updateGame({ commit }, game) {
    try {
      const response = await this.$axios.$put(`http://localhost:5242/api/game/${game.id}`, game);
      commit('updateGame', response);
    } catch (error) {
      console.error('Error updating game:', error);
    }
  },
  async deleteGame({ commit }, gameId) {
    try {
      await this.$axios.$delete(`http://localhost:5242/api/game/${gameId}`);
      commit('deleteGame', gameId);
    } catch (error) {
      console.error('Error deleting game:', error);
    }
  },
  async fetchCategories({ commit }) {
    try {
      const response = await this.$axios.$get('http://localhost:5242/api/category');
      commit('setCategories', response);
    } catch (error) {
      console.error('Error fetching categories:', error);
    }
  },
  async addCategory({ commit }, category) {
    try {
      const response = await this.$axios.$post('http://localhost:5242/api/category', category);
      commit('addCategory', response);
    } catch (error) {
      console.error('Error adding category:', error);
    }
  },
};
