import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { createBrowserRouter, RouterProvider } from "react-router-dom"
import ProductList from "./Products/ProductList.jsx"
import ProductDetail from "./Products/ProductDetail.jsx"
import store from "./Infrastructure/Redux/store.js"
import { Provider } from 'react-redux'
import CreateProduct from './Products/CreateProduct.jsx'
import UpdateProduct from './Products/UpdateProduct.jsx'

const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "/",
                element: <ProductList />
            },
            {
                path: "/Product/:id",
                element: <ProductDetail/>
            },
            {
                path: "/Product/Create",
                element: <CreateProduct/>
            },
            {
                path: "/Product/Update/:id",
                element: <UpdateProduct />
            }
        ]
    }

]);


ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <Provider store={store}>
            <RouterProvider router={router} />
        </Provider>
  </React.StrictMode>,
)
