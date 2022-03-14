import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    cartItems: [],
    totalPrice: 0
  },
  mutations: {
    addToCart(state, item) {
      state.cartItems.push(item)
      state.totalPrice += parseInt(item.price)
    },
    removeFromCart(state, item) {
      state.cartItems.splice(state.cartItems.indexOf(item), 1)
      state.totalPrice -= parseInt(item.price)
    },
    deleteFromCart(state, item) {
      let itemsToRemove = state.cartItems.filter(product => product.id === item.id)
      state.cartItems = state.cartItems.filter(product => product.id !== item.id);
      state.totalPrice -= itemsToRemove.reduce((total, item) => total + parseInt(item.price), 0);
    },
    emptyCart(state) {
      state.cartItems = []
      state.totalPrice = 0
    }
  },
  actions: {
    addToCart({ commit }, item) {
      commit('addToCart', item)
    },
    removeFromCart({commit}, item) {
      commit('removeFromCart', item)
    },
    deleteFromCart({commit}, item) {
      commit('deleteFromCart', item)
    }
  },
  modules: {
  },
  getters: {
    cartItems(state) {
      return state.cartItems
    },
    totalPrice(state) {
      return state.totalPrice
    }
  }
})
