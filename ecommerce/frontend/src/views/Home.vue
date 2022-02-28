<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <div>
      Listado de productos
    </div>
    <div class="d-flex flex-wrap justify-content-center mt-2">

    <b-card v-for="product in products" v-bind:key="product.id"
    :title="product.name"
    :img-src="product.mainImage"
    :img-alt="product.name"
    tag="article"
    style="max-width:20rem;"
    class="m-3">
      <b-card-text>{{product.description.substring(0,100)+ "..."}}</b-card-text>
      <div class="d-flex justify-content-center" style="gap: 0.5rem;">
        <b-button variant="primary">View</b-button>
        <b-button variant="primary">Add</b-button>
      </div>
    </b-card>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  created () {
    fetch('http://localhost:3000/products')
      .then(response => response.json())
      .then(json => {
        this.products = json
      })
  },
  data() {
    return {
      products: []
    }
  },
  components: {
  }
}
</script>
