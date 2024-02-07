import { configureStore } from '@reduxjs/toolkit'
import ProductReducer from './ProductReducer'
import BuyerReducer from './BuyerReducer'

export default configureStore({
    reducer: {
        product: ProductReducer,
        buyer: BuyerReducer
    },
})