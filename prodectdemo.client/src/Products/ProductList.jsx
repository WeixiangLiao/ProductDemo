import { useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { useSelector, useDispatch } from 'react-redux'
import { getAllProducts } from "../Infrastructure/Redux/ProductReducer"
import { NavLink } from "react-router-dom";

function ProductList() {
    const products = useSelector((state) => state.product.values);
    const dispatch = useDispatch();


    useEffect(
        () => {
            dispatch(getAllProducts())
        },
        [dispatch]

    )
    

    return (
        <div>
            <h2>Product List</h2>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>SKU</th>
                        <th>Title</th>
                        <th>Status</th>
                        <th>Detail</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map((product, index) => (
                        <tr key={index}>
                            <td>{product.sku}</td>
                            <td>{product.title}</td>
                            <td>{product.active ? "Active" : "Inactive"}</td>
                            <td>
                                <NavLink to={"Product/" + product.id}>
                                Detail
                                </NavLink>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    );
}



export default ProductList;