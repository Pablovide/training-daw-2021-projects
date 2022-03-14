<template>
  <b-card
    :title="product.name"
    :img-src="product.mainImage"
    :img-alt="product.name"
    tag="article"
    style="max-width: 20rem"
    class="m-3"
  >
    <b-card-text>{{ product.short }}</b-card-text>
    <b-card-text style="font-weight: bold; text-align: end"
      >${{ product.price }}</b-card-text
    >
    <div class="d-flex justify-content-center" style="gap: 0.5rem">
      <router-link :to="{ name: 'Product', params: { id: product.id } }"
        ><b-button variant="primary">View</b-button></router-link
      >
      <b-button variant="primary" v-on:click="addProductToCart(product)"
        >Add</b-button
      >
    </div>
  </b-card>
</template>

<script>
export default {
  props: {
    product: {
      type: Object,
      required: true,
    },
  },
  methods: {
    addProductToCart() {
      this.$store.commit("addToCart", this.product);
    },
  },
};
</script>

<style>
</style>