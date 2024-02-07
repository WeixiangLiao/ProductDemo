import { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { getProductById } from '../Infrastructure/Redux/ProductReducer';
import axios from 'axios';

function ProductDetail() {
    const { id } = useParams();
    const product = useSelector((state) => state.product.value);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    useEffect(() => {
        dispatch(getProductById(id));
    }, [dispatch, id]);

    const handleUpdateClick = () => {
        navigate(`/Product/Update/${id}`);
    };

    const handleDeleteClick = async () => {
        try {
            await axios.delete(`https://localhost:7030/Products/${id}`)
            navigate('/');
        }
        catch (error) {
            console.log(error);
        }

    };


    if (!product) {
        return (<h1>Product not found</h1>);
    }

    const { sku, title, description, buyer } = product;

    return (
        <div className="container mt-5">
            <div className="d-flex justify-content-between align-items-center">
                <h2>{title}</h2>
                <button className="btn btn-primary" onClick={handleUpdateClick}>Update</button>
                <button className="btn btn-primary" onClick={handleDeleteClick}>Delete</button>
            </div>
            <div className="card">
                <div className="card-body">
                    <p><strong>ID:</strong> {id}</p>
                    <p><strong>SKU:</strong> {sku}</p>
                    <p><strong>Description:</strong> {description}</p>
                    <p><strong>Buyer Name:</strong> {buyer.name}</p>
                    <p><strong>Buyer Email:</strong> {buyer.email}</p>
                    <p><strong>Status:</strong> {product.active ? "Active" : "Inactive"}</p>
                </div>
            </div>
        </div>
    );
}

export default ProductDetail;