import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'
import axios from 'axios';

 export const getAllProducts = createAsyncThunk(
    "products/getAll",
     async (_,thunkAPI) => {
         try {
             const response = await axios.get("https://localhost:7030/Products");
             return response.data;
         }
         catch (error) {
             console.log(error.message);
             return thunkAPI.rejectWIthValue(error.message)
         }

    }
)

export const getProductById = createAsyncThunk(
    "products/getById",
    async (id, thunkAPI) => {
        console.log(id);
        try {
            const response = await axios.get("https://localhost:7030/Products/" + id);
            return response.data;
        }
        catch (error) {
            console.log(error.message);
            return thunkAPI.rejectWIthValue(error.message)
        }

    }
)


export const productSlice =  createSlice(
    {
        name: "product",
        initialState: {
            values: [],
            value:null
        },
        reducer: {},
        extraReducers: (builder) => {
            builder.addCase(
                getAllProducts.fulfilled,
                (state, action) => {
                    state.values = action.payload
                }
            );

            builder.addCase(
                getProductById.fulfilled,
                (state, action) => {
                    state.value = action.payload;
                }
            )
  
        }
        
    }

)


export default productSlice.reducer