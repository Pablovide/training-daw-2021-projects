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
  data.cart.push({
    id: 0,
    products: [{
      "id": 0,
      "name": "Fantastic Cotton Ball",
      "category": "Shoes",
      "short": "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
      "description": "Ratione sint velit in. Ut ea culpa sunt velit. Inventore sint quidem asperiores accusamus. Totam cumque sapiente molestiae aspernatur ut eum qui totam. Quam sed voluptates similique et tempore neque non quidem. Officia reprehenderit itaque quia doloremque voluptas.\n \rLabore officiis sit quia ipsa autem quo et. Sunt id deserunt cupiditate ut et autem. Est maiores soluta quibusdam. Velit unde corporis deserunt est ut sequi. Numquam est aperiam.\n \rAut doloribus expedita sit sit dicta quia ad adipisci. Magni soluta ex deserunt totam et. Alias quas non. Est fugiat deleniti perferendis corporis dicta et. Alias ipsum eum rerum asperiores voluptates sint at.",
      "price": "240.00",
      "mainImage": "http://placeimg.com/320/240/abstract?81868",
      "disccount": 0,
      "images": [
        "http://placeimg.com/320/240/abstract?90278",
        "http://placeimg.com/320/240/abstract?98268"
      ]
    }, {
      "id": 0,
      "name": "Fantastic Cotton Ball",
      "category": "Shoes",
      "short": "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
      "description": "Ratione sint velit in. Ut ea culpa sunt velit. Inventore sint quidem asperiores accusamus. Totam cumque sapiente molestiae aspernatur ut eum qui totam. Quam sed voluptates similique et tempore neque non quidem. Officia reprehenderit itaque quia doloremque voluptas.\n \rLabore officiis sit quia ipsa autem quo et. Sunt id deserunt cupiditate ut et autem. Est maiores soluta quibusdam. Velit unde corporis deserunt est ut sequi. Numquam est aperiam.\n \rAut doloribus expedita sit sit dicta quia ad adipisci. Magni soluta ex deserunt totam et. Alias quas non. Est fugiat deleniti perferendis corporis dicta et. Alias ipsum eum rerum asperiores voluptates sint at.",
      "price": "240.00",
      "mainImage": "http://placeimg.com/320/240/abstract?81868",
      "disccount": 0,
      "images": [
        "http://placeimg.com/320/240/abstract?90278",
        "http://placeimg.com/320/240/abstract?98268"
      ]
    }, {
      "id": 0,
      "name": "Fantastic Cotton Ball",
      "category": "Shoes",
      "short": "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
      "description": "Ratione sint velit in. Ut ea culpa sunt velit. Inventore sint quidem asperiores accusamus. Totam cumque sapiente molestiae aspernatur ut eum qui totam. Quam sed voluptates similique et tempore neque non quidem. Officia reprehenderit itaque quia doloremque voluptas.\n \rLabore officiis sit quia ipsa autem quo et. Sunt id deserunt cupiditate ut et autem. Est maiores soluta quibusdam. Velit unde corporis deserunt est ut sequi. Numquam est aperiam.\n \rAut doloribus expedita sit sit dicta quia ad adipisci. Magni soluta ex deserunt totam et. Alias quas non. Est fugiat deleniti perferendis corporis dicta et. Alias ipsum eum rerum asperiores voluptates sint at.",
      "price": "240.00",
      "mainImage": "http://placeimg.com/320/240/abstract?81868",
      "disccount": 0,
      "images": [
        "http://placeimg.com/320/240/abstract?90278",
        "http://placeimg.com/320/240/abstract?98268"
      ]
    }, {
      "id": 0,
      "name": "Fantastic Cotton Ball",
      "category": "Shoes",
      "short": "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
      "description": "Ratione sint velit in. Ut ea culpa sunt velit. Inventore sint quidem asperiores accusamus. Totam cumque sapiente molestiae aspernatur ut eum qui totam. Quam sed voluptates similique et tempore neque non quidem. Officia reprehenderit itaque quia doloremque voluptas.\n \rLabore officiis sit quia ipsa autem quo et. Sunt id deserunt cupiditate ut et autem. Est maiores soluta quibusdam. Velit unde corporis deserunt est ut sequi. Numquam est aperiam.\n \rAut doloribus expedita sit sit dicta quia ad adipisci. Magni soluta ex deserunt totam et. Alias quas non. Est fugiat deleniti perferendis corporis dicta et. Alias ipsum eum rerum asperiores voluptates sint at.",
      "price": "240.00",
      "mainImage": "http://placeimg.com/320/240/abstract?81868",
      "disccount": 0,
      "images": [
        "http://placeimg.com/320/240/abstract?90278",
        "http://placeimg.com/320/240/abstract?98268"
      ]
    }],
  })

  return data
}