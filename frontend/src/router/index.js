import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path:'/Detail',
    name:'Detail',
    component: ()=>import("@/views/Detail.vue"),
    props:true,
  },{
    path:'/Create',
    name:'Create',
    component: ()=>import("@/views/Create.vue"),
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
