// import { faker } from '@faker-js/faker';
const { faker } = require('@faker-js/faker')

module.exports = () => {
  let data = {
    products: [],
    cart: [],
    orders: []
  }

  for (let i = 0; i < 50; i++) {
    let images = []
    let maxImages = faker.datatype.number(4) + 1
    for (let i = 0; i < maxImages; i++) {
      images.push(faker.image.abstract(320, 240, true))
    }

    data.products.push({
      id: i,
      name: faker.commerce.productName(),
      category: faker.commerce.product(),
      short: faker.commerce.productDescription(),
      description: faker.lorem.paragraphs(3),
      price: faker.commerce.price(),
      mainImage: faker.image.abstract(320, 240, true),
      disccount: faker.datatype.boolean() ? faker.datatype.number(30) + 1 : 0,
      images: images
    })
  }
  data.cart.push({ id: 0, products: []})

  return data
}