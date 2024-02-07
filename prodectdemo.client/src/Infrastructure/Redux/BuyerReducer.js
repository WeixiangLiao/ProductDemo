import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'
import axios from 'axios';

 export const getAllBuyers = createAsyncThunk(
    "buyers/getAll",
     async (_,thunkAPI) => {
         try {
             const response = await axios.get("https://localhost:7030/Buyers");
             return response.data;
         }
         catch (error) {
             console.log(error.message);
             return thunkAPI.rejectWIthValue(error.message)
         }

    }
)

export const getBuyerById = createAsyncThunk(
    "buyers/getById",
    async (id, thunkAPI) => {
        console.log(id);
        try {
            const response = await axios.get("https://localhost:7030/Buyers/" + id);
            return response.data;
        }
        catch (error) {
            console.log(error.message);
            return thunkAPI.rejectWIthValue(error.message)
        }

    }
)


export const buyerSlice =  createSlice(
    {
        name: "buyer",
        initialState: {
            values: [],
            value:null
        },
        reducer: {},
        extraReducers: (builder) => {
            builder.addCase(
                getAllBuyers.fulfilled,
                (state, action) => {
                    state.values = action.payload
                }
            );

            builder.addCase(
                getBuyerById.fulfilled,
                (state, action) => {
                    state.value = action.payload;
                }
            )
  
        }
        
    }

)


export default buyerSlice.reducer