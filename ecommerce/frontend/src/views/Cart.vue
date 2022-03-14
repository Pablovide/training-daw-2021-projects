<template>
  <div>
    <div v-if="checkoutDone">
      <p>Producto comprado con éxito</p>
      <router-link :to="{ name: 'Home' }"
        ><b-button variant="primary">Volver</b-button></router-link
      >
    </div>
    <div v-else style="margin: 0 auto; max-width: 30rem" class="">
      <div
        v-for="product in selectedProducts"
        v-bind:key="product.id"
        style="margin-bottom: 2em"
      >
        <div
          class="d-flex"
          style="align-items: center; justify-content: space-around"
        >
          <b-button style="height: 50%" v-on:click="deleteProduct(product)"
            >Delete</b-button
          >
          <div>{{ product.name }}</div>
          <div>{{ product.qtity }}</div>
          <div class="d-flex flex-column" style="gap: 0.5em">
            <b-button v-on:click="addProductToCart(product)">+</b-button>
            <b-button v-on:click="removeProductFromCart(product)">-</b-button>
          </div>
          <div>${{ product.price * product.qtity }}</div>
        </div>
      </div>
      <div class="d-flex justify-content-center" style="gap: 1em">
        <div>TOTAL</div>
        <div>${{ totalPrice }}</div>
      </div>
      <b-button variant="primary" v-on:click="checkout()">Checkout</b-button>
    </div>
  </div>
</template>

<script>
import store from "../store/index.js";
export default {
  created() {
    this.productList = store.getters.cartItems;
    this.productList.forEach((element) => {
      if (this.selectedProducts.find((product) => product.id === element.id)) {
        this.selectedProducts.find(
          (product) => product.id === element.id
        ).qtity += 1;
      } else {
        this.selectedProducts.push({
          id: element.id,
          name: element.name,
          price: element.price,
          qtity: 1,
        });
      }
    });
    this.totalPrice = store.getters.totalPrice;
  },
  data() {
    return {
      cart: {},
      productList: [],
      selectedProducts: [],
      totalPrice: 0,
      checkoutDone: false,
    };
  },
  methods: {
    addProductToCart(product) {
      this.$store.commit("addToCart", product);
      this.update();
    },
    update() {
      this.selectedProducts = [];
      this.productList = store.getters.cartItems;
      this.productList.forEach((element) => {
        if (
          this.selectedProducts.find((product) => product.id === element.id)
        ) {
          this.selectedProducts.find(
            (product) => product.id === element.id
          ).qtity += 1;
        } else {
          this.selectedProducts.push({
            id: element.id,
            name: element.name,
            price: element.price,
            qtity: 1,
          });
        }
      });
      this.totalPrice = store.getters.totalPrice;
    },
    removeProductFromCart(product) {
      this.$store.commit("removeFromCart", product);
      this.update();
    },
    deleteProduct(product) {
      this.$store.commit("deleteFromCart", product);
      this.update();
    },
    checkout() {
      this.checkoutDone = true;
      fetch(
        `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/orders/`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            products: this.productList,
          }),
        }
      );
      this.$store.commit("emptyCart");
      this.update();
    },
  },
};
</script>

<style>
</style>