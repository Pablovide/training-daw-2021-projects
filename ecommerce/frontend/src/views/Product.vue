<template>
  <div class="d-flex justify-content-center">
    <b-card :title="product.name" style="max-width: 25rem" class="mt-3"
      ><b-carousel
        v-model="slide"
        controls
        :interval="4000"
      >
        <b-carousel-slide
          v-for="(image, index) in product.images"
          :key="index"
          :img-src="image"
          :img-alt="product.name"
        ></b-carousel-slide>
      </b-carousel>
      <b-card-text>{{ product.description }}</b-card-text>
      <b-card-text style="font-weight: bold; text-align: end"
        >${{ product.price }}</b-card-text
      >
      <div class="d-flex justify-content-center" style="gap: 0.5rem">
        <router-link :to="{ name: 'Home' }"
          ><b-button variant="primary">Home</b-button></router-link
        >
        <b-button variant="primary" v-on:click="addProductToCart()"
          >Add to cart</b-button
        >
      </div></b-card
    >
  </div>
</template>

<script>
export default {
  created() {
    fetch(`${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/products/` + this.$route.params.id)
      .then((response) => response.json())
      .then((json) => {
        this.product = json;
      });
  },
  props: {
    id: Number,
  },
  data() {
    return {
      product: {}
    };
  },
  methods: {
      addProductToCart(){
        this.$store.commit('addToCart', this.product);
    }
  }
};
</script>

<style>
</style>